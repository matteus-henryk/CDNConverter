using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace CDNConverter.API.Infrastructure.DataAccess.Repositories
{
    public class LogDirectoryRepository : ILogDirectoryReadOnlyRepository, ILogDirectoryWriteOnlyRepository
    {
        private readonly string _originalDirectory;
        private readonly string _convertedDirectory;
        private readonly IConfiguration _configuration;

        public LogDirectoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _originalDirectory = $"{Directory.GetCurrentDirectory()}{_configuration.GetSection("UploadSettings")["OriginalLogDirectory"]}";
            _convertedDirectory = $"{Directory.GetCurrentDirectory()}{_configuration.GetSection("UploadSettings")["ConvertedLogDirectory"]}";
        }

        #region Original

        public async Task<OriginalLog> SaveOriginalLog(byte[] fileBytes)
        {
            if (!Directory.Exists(_originalDirectory))
                Directory.CreateDirectory(_originalDirectory);

            var id = Guid.NewGuid();
            var fileName = $"{id}_Original.txt";
            var filePath = Path.Combine(_originalDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                await stream.WriteAsync(fileBytes, 0, fileBytes.Length);

            return new OriginalLog { Id = id, OriginalLogPath = filePath };
        }

        public async Task<byte[]> GetAllOriginalLogs()
        {
            var memoryStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var files = Directory.GetFiles(_originalDirectory, "*.txt");

                if (files.Length == 0) return null;

                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var entry = zipArchive.CreateEntry(fileName);

                    using (var entryStream = entry.Open())
                    using (var fileStream = File.OpenRead(file))
                    {
                        await fileStream.CopyToAsync(entryStream);
                    }
                }
            }

            memoryStream.Position = 0;

            return memoryStream.ToArray();
        }
    
        public async Task<byte[]> GetOriginalLogById(Guid id)
        {
            var fullPath = Path.Combine(_originalDirectory, id + "_Original.txt");

            var fileExists = Directory.GetFiles(_originalDirectory, id + "_Original.txt");

            if (fileExists.Length == 0) return null;

            return await File.ReadAllBytesAsync(fullPath);
        }


        #endregion


        #region Converted

        public async Task<(ConvertedLog, byte[])> ConvertAndSaveLog(byte[] fileBytes)
        {
            if (!Directory.Exists(_convertedDirectory))
                Directory.CreateDirectory(_convertedDirectory);

            var id = Guid.NewGuid();

            var fileName = $"{id}_Converted.txt";
            string filePath = Path.Combine(_convertedDirectory, fileName);
            var codeRegex = @"^(\d+)";
            var timeRegex = @"\|(\d+)(?=\.\d+)?$";
            var statusCodeRegex = @"(?<=\|)(\d+)(?=\|)";
            var methodRegex = @"^(.*?)(?=\/)";
            var contentRegex = @"\/([^\/]*)(?=\sHTTP)";
            var typeRegex = @"(?:[^|]*\|){2}([^|]*)";

            using (MemoryStream imputMemoryStream = new MemoryStream(fileBytes))
            using (StreamReader reader = new StreamReader(imputMemoryStream))
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fileStream))
            using (MemoryStream outputMemoryStream = new MemoryStream())
            {
                using (StreamWriter memoryWriter = new StreamWriter(outputMemoryStream))
                {
                    var headerLines = new[]
                    {
                        "#Version: 1.0",
                        "#Date: " + DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"),
                        "#Fields: provider http-method status-code uri-path time-taken response-size cache-status"
                    };

                    foreach (var header in headerLines)
                    {
                        await writer.WriteLineAsync(header);
                        await memoryWriter.WriteLineAsync(header);
                    }

                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var code = Regex.Match(line, codeRegex).Groups[1].Value;
                        var statusCore = Regex.Match(line, statusCodeRegex).Groups[1].Value;
                        var type = Regex.Match(line, typeRegex).Groups[1].Value;
                        var methodAndContent = Regex.Match(line, "\"([^\"]*)\"").Groups[1].Value;
                        var method = Regex.Match(methodAndContent, methodRegex).Groups[1].Value;
                        var content = Regex.Match(methodAndContent, contentRegex).Groups[1].Value;
                        var time = Regex.Match(line, timeRegex).Groups[1].Value;

                        var convertedLine = $"\"MINHA CDN\" {method} {statusCore} /{content} {time} {code} {type}";

                        await writer.WriteLineAsync(convertedLine);
                        await memoryWriter.WriteLineAsync(convertedLine);
                    }

                    await memoryWriter.FlushAsync();
                }

                var file = outputMemoryStream.ToArray();
                var log = new ConvertedLog { Id = id, ConvertedLogPath = filePath };

                return (log, file);
            }

        }

        public async Task<byte[]> GetConvertedLogById(Guid id)
        {
            var fullPath = Path.Combine(_convertedDirectory, id + "_Converted.txt");

            var fileExists = Directory.GetFiles(_convertedDirectory, id + "_Converted.txt");

            if (fileExists.Length == 0) return null;

            return await File.ReadAllBytesAsync(fullPath);
        }

        public async Task<byte[]> GetAllConvertedLogs()
        {
            var memoryStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var files = Directory.GetFiles(_convertedDirectory, "*.txt");

                if (files.Length == 0) return null;

                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var entry = zipArchive.CreateEntry(fileName);

                    using (var entryStream = entry.Open())
                    using (var fileStream = File.OpenRead(file))
                    {
                        await fileStream.CopyToAsync(entryStream);
                    }
                }
            }

            memoryStream.Position = 0;

            return memoryStream.ToArray();
        }

        #endregion
    }
}

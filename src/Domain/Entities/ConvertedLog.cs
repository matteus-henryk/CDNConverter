using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Entities
{
    public class ConvertedLog
    {
        public Guid Id { get; private set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string ConvertedLogPath { get; private set; }
        public Guid OriginalLogId { get; set; }
        public OriginalLog OriginalLog { get; set; }

        public async Task<byte[]> ConvertAndSaveLogFile(byte[] fileBytes, string ConvertedLogDirectory)
        {
            if (!Directory.Exists(ConvertedLogDirectory))
                Directory.CreateDirectory(ConvertedLogDirectory);

            var id = Guid.NewGuid();

            var fileName = $"{id}_Converted.txt";
            string filePath = Path.Combine(ConvertedLogDirectory, fileName);
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

                Id = id;
                ConvertedLogPath = filePath;

                return outputMemoryStream.ToArray();
            }
        }
    }
}

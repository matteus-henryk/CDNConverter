using CDNConverter.API.Domain.Interfaces.Services;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class GetAllConvertedLogsFilesService : IGetAllConvertedLogsFilesService
    {

        public async Task<byte[]> ExecuteAsync()
        {
            var originalLogDirectory = $"{Directory.GetCurrentDirectory()}\\Uploads\\ConvertedLogs";

            var memoryStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var files = Directory.GetFiles(originalLogDirectory, "*.txt");

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
    }
}

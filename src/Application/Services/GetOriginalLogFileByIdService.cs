using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Extentions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class GetOriginalLogFileByIdService : IGetOriginalLogFileByIdService
    {
        public async Task<byte[]> ExecuteAsync(Guid id)
        {
            await id.ValidateAsync();

            var originalLogDirectory = $"{Directory.GetCurrentDirectory()}\\OriginalLogs";

            var fullPath = Path.Combine(originalLogDirectory, id + "_Original.txt");

            var fileExists = Directory.GetFiles(originalLogDirectory, id + "_Original.txt");

            if (fileExists.Length == 0) return null;

            return await File.ReadAllBytesAsync(fullPath);

        }
    }
}

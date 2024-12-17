using System;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Entities
{
    public class OriginalLog
    {
        public Guid Id { get; private set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string OriginalLogPath { get; private set; }

        public async Task SaveLogsToFile(byte[] fileBytes, string originalLogDirectory)
        {
            if (!Directory.Exists(originalLogDirectory))
                Directory.CreateDirectory(originalLogDirectory);

            var id = Guid.NewGuid();
            var fileName = $"{id}_Original.txt";
            var filePath = Path.Combine(originalLogDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                await stream.WriteAsync(fileBytes, 0, fileBytes.Length);

            Id = id;
            OriginalLogPath = filePath;
        }
    }
}

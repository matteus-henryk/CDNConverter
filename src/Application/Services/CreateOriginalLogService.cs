using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using CDNConverter.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class CreateOriginalLogService : ICreateOriginalLogService
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOriginalLogService(ILogWriteOnlyRepository logWriteOnlyRepository, IUnitOfWork unitOfWork)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseOriginalLogJson> ExecuteAsync(IFormFile file)
        {
            await file.ValidateAsync();

            var originalLogDirectory = $"{Directory.GetCurrentDirectory()}\\Uploads\\OriginalLogs";

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var log = new OriginalLog();

            await log.SaveLogsToFile(fileBytes, originalLogDirectory);

            await _logWriteOnlyRepository.SaveLog(log);

            await _unitOfWork.Commit();

            return new ResponseOriginalLogJson
            {
                OriginalLogId = log.Id,
                CreatedOnOriginalLog = log.CreatedOn,
                OriginalLogPath = log.OriginalLogPath
            };
        }

    }
}

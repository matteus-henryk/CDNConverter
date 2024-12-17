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
    public class ConvertOriginalLogByFileReturnService : IConvertOriginalLogByFileReturnService
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateOriginalLogService _createOriginalLogService;

        public ConvertOriginalLogByFileReturnService(ILogWriteOnlyRepository logWriteOnlyRepository, IUnitOfWork unitOfWork, ICreateOriginalLogService createOriginalLogService)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _createOriginalLogService = createOriginalLogService;
        }

        public async Task<ResponseConvertedLogFileJson> ExecuteAsync(IFormFile file)
        {
            await file.ValidateAsync();

            var originalLog = await _createOriginalLogService.ExecuteAsync(file);

            var convertedLogDirectory = $"{Directory.GetCurrentDirectory()}\\ConvertedLogs";

            byte[] fileByte;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileByte = memoryStream.ToArray();
            }

            var convertedLog = new ConvertedLog();
            var convertedFileResult = await convertedLog.ConvertAndSaveLogFile(fileByte, convertedLogDirectory);
            convertedLog.OriginalLogId = originalLog.OriginalLogId;

            await _logWriteOnlyRepository.SaveConvertedLog(convertedLog);
            await _unitOfWork.Commit();

            return new ResponseConvertedLogFileJson { Id = convertedLog.Id, ConvertedLogFile = convertedFileResult };
        }
    }
}

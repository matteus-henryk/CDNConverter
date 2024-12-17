using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class ConvertOriginalLogByIdFileReturnService : IConvertOriginalLogByIdFileReturnService
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConvertOriginalLogByIdFileReturnService(ILogWriteOnlyRepository logWriteOnlyRepository, ILogReadOnlyRepository logReadOnlyRepository, IUnitOfWork unitOfWork)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _logReadOnlyRepository = logReadOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseConvertedLogFileJson> ExecuteAsync(Guid id)
        {
            var logExist = await _logReadOnlyRepository.ExistConvertedLogAsync(id);

            await id.ValidateAsync(logExist);

            var originalLog = _logReadOnlyRepository.GetOriginalLogById(id);
            var fullPath = Path.Combine(originalLog.OriginalLogPath);

            var originalLogFile = await File.ReadAllBytesAsync(fullPath);

            var convertedLogDirectory = $"{Directory.GetCurrentDirectory()}\\ConvertedLogs";

            var convertedLog = new ConvertedLog();
            var convertedFileResult = await convertedLog.ConvertAndSaveLogFile(originalLogFile, convertedLogDirectory);
            convertedLog.OriginalLogId = originalLog.Id;

            await _logWriteOnlyRepository.SaveConvertedLog(convertedLog);
            await _unitOfWork.Commit();

            return new ResponseConvertedLogFileJson { Id = convertedLog.Id, ConvertedLogFile = convertedFileResult };
        }
    }
}

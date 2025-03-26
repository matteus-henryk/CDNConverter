using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class ConvertOriginalLogByIdUseCase : IConvertOriginalLogByIdUseCase
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogDirectoryWriteOnlyRepository _logDirectoryWriteOnlyRepository;

        public ConvertOriginalLogByIdUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, ILogReadOnlyRepository logReadOnlyRepository, IUnitOfWork unitOfWork, ILogDirectoryWriteOnlyRepository logDirectoryWriteOnlyRepository)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _logReadOnlyRepository = logReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _logDirectoryWriteOnlyRepository = logDirectoryWriteOnlyRepository;
        }

        public async Task<ResponseConvertedLogJson> ExecuteAsync(Guid id)
        {
            var logExist = await _logReadOnlyRepository.ExistConvertedLogAsync(id);

            await id.ValidateAsync(logExist);

            var originalLog = _logReadOnlyRepository.GetOriginalLogById(id);
            var fullPath = Path.Combine(originalLog.OriginalLogPath);

            var originalLogFile = await File.ReadAllBytesAsync(fullPath);

            var (convertedLog, _) = await _logDirectoryWriteOnlyRepository.ConvertAndSaveLog(originalLogFile);

            convertedLog.OriginalLogId = originalLog.Id;

            await _logWriteOnlyRepository.SaveConvertedLog(convertedLog);
            await _unitOfWork.Commit();

            return new ResponseConvertedLogJson
            {
                IdConvertedLog = convertedLog.Id,
                OriginalLog = new ResponseOriginalLogJson
                {
                    OriginalLogId = originalLog.Id,
                    CreatedOnOriginalLog = originalLog.CreatedOn,
                    OriginalLogPath = originalLog.OriginalLogPath,
                },
                PathConvertedLog = convertedLog.ConvertedLogPath
            };
        }
    }
}

using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class ConvertOriginalLogByIdFileReturnUseCase : IConvertOriginalLogByIdFileReturnUseCase
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogDirectoryWriteOnlyRepository _logDirectoryWriteOnlyRepository;

        public ConvertOriginalLogByIdFileReturnUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, ILogReadOnlyRepository logReadOnlyRepository, IUnitOfWork unitOfWork, ILogDirectoryWriteOnlyRepository logDirectoryWriteOnlyRepository)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _logReadOnlyRepository = logReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _logDirectoryWriteOnlyRepository = logDirectoryWriteOnlyRepository;
        }

        public async Task<ResponseConvertedLogFileJson> ExecuteAsync(Guid id)
        {
            var logExist = await _logReadOnlyRepository.ExistConvertedLogAsync(id);

            await id.ValidateAsync(logExist);

            var originalLog = _logReadOnlyRepository.GetOriginalLogById(id);
            var fullPath = Path.Combine(originalLog.OriginalLogPath);

            var originalLogFile = await File.ReadAllBytesAsync(fullPath);

            var (convertedLog, convertedFileResult) = await _logDirectoryWriteOnlyRepository.ConvertAndSaveLog(originalLogFile);

            convertedLog.OriginalLogId = originalLog.Id;

            await _logWriteOnlyRepository.SaveConvertedLog(convertedLog);
            await _unitOfWork.Commit();

            return new ResponseConvertedLogFileJson { Id = convertedLog.Id, ConvertedLogFile = convertedFileResult };
        }
    }
}

using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class ConvertOriginalLogByFileUseCase : IConvertOriginalLogByFileUseCase
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateOriginalLogUseCase _createOriginalLogUseCase;
        private readonly ILogDirectoryWriteOnlyRepository _logDirectoryWriteOnlyRepository;

        public ConvertOriginalLogByFileUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, IUnitOfWork unitOfWork, ICreateOriginalLogUseCase createOriginalLogUseCase, ILogDirectoryWriteOnlyRepository logDirectoryWriteOnlyRepository)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _createOriginalLogUseCase = createOriginalLogUseCase;
            _logDirectoryWriteOnlyRepository = logDirectoryWriteOnlyRepository;
        }

        public async Task<ResponseConvertedLogJson> ExecuteAsync(IFormFile file)
        {
            await file.ValidateAsync();

            var originalLog = await _createOriginalLogUseCase.ExecuteAsync(file);

            byte[] fileByte;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileByte = memoryStream.ToArray();
            }

            var (convertedLog, _) = await _logDirectoryWriteOnlyRepository.ConvertAndSaveLog(fileByte); 

            convertedLog.OriginalLogId = originalLog.OriginalLogId;

            await _logWriteOnlyRepository.SaveConvertedLog(convertedLog);
            await _unitOfWork.Commit();

            return new ResponseConvertedLogJson
            {
                IdConvertedLog = convertedLog.Id,
                PathConvertedLog = convertedLog.ConvertedLogPath,
                OriginalLog = originalLog,
                CreatedOnConvertedLog = convertedLog.CreatedOn,
            };
        }
    }
}

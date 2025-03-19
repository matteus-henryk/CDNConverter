using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class CreateOriginalLogUseCase : ICreateOriginalLogUseCase
    {
        private readonly ILogWriteOnlyRepository _logWriteOnlyRepository;
        private readonly ILogDirectoryWriteOnlyRepository _logDirectoryWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOriginalLogUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, IUnitOfWork unitOfWork, ILogDirectoryWriteOnlyRepository logDirectoryWriteOnlyRepository)
        {
            _logWriteOnlyRepository = logWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _logDirectoryWriteOnlyRepository = logDirectoryWriteOnlyRepository;
        }

        public async Task<ResponseOriginalLogJson> ExecuteAsync(IFormFile file)
        {
            await file.ValidateAsync();

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var log = await _logDirectoryWriteOnlyRepository.SaveOriginalLog(fileBytes);

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

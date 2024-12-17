using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using System;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class GetConvertedAndOriginalLogByIdService : IGetConvertedAndOriginalLogByIdService
    {
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;

        public GetConvertedAndOriginalLogByIdService(ILogReadOnlyRepository logReadOnlyRepository)
        {
            _logReadOnlyRepository = logReadOnlyRepository;
        }

        public async Task<ResponseConvertedLogJson> ExecuteAsync(Guid id)
        {
            await id.ValidateAsync();

            var convertedLog = await _logReadOnlyRepository.GetConvertedLogById(id);

            if (convertedLog == null) return null;

            var result = new ResponseConvertedLogJson
            {
                IdConvertedLog = convertedLog.Id,
                CreatedOnConvertedLog = convertedLog.CreatedOn,
                PathConvertedLog = convertedLog.ConvertedLogPath,
                OriginalLog = new ResponseOriginalLogJson
                {
                    OriginalLogId = convertedLog.OriginalLog.Id,
                    CreatedOnOriginalLog = convertedLog.OriginalLog.CreatedOn,
                    OriginalLogPath = convertedLog.OriginalLog.OriginalLogPath
                }
            };

            return result;
        }
    }
}

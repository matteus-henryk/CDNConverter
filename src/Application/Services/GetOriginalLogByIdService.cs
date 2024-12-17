using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Extentions;
using CDNConverter.API.Shared.Comunication;
using System;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.Services
{
    public class GetOriginalLogByIdService : IGetOriginalLogByIdService
    {
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;

        public GetOriginalLogByIdService(ILogReadOnlyRepository logReadOnlyRepository)
        {
            _logReadOnlyRepository = logReadOnlyRepository;
        }

        public async Task<ResponseOriginalLogJson> ExecuteAsync(Guid id)
        {
            await id.ValidateAsync();

            var log = _logReadOnlyRepository.GetOriginalLogById(id);

            if (log == null) return null;

            var result = new ResponseOriginalLogJson
            {
                OriginalLogId = log.Id,
                CreatedOnOriginalLog = log.CreatedOn,
                OriginalLogPath = log.OriginalLogPath
            };

            return result;
        }
    }
}

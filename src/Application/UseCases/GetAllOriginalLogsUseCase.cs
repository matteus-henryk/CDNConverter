using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Shared.Comunication;
using System.Collections.Generic;
using System.Linq;

namespace CDNConverter.API.Application.UseCases
{
    public class GetAllOriginalLogsUseCase : IGetAllOriginalLogsUseCase
    {
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;

        public GetAllOriginalLogsUseCase(ILogReadOnlyRepository logReadOnlyRepository)
        {
            _logReadOnlyRepository = logReadOnlyRepository;
        }

        public List<ResponseOriginalLogJson> Execute()
        {
            var logs = _logReadOnlyRepository.GetAllOriginalsLogs();

            if (logs == null) return null;

            var result = logs.Select(log => new ResponseOriginalLogJson
            {
                OriginalLogId = log.Id,
                CreatedOnOriginalLog = log.CreatedOn,
                OriginalLogPath = log.OriginalLogPath
            }).ToList();

            return result;
        }
    }
}

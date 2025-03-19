using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Shared.Comunication;
using System.Collections.Generic;
using System.Linq;

namespace CDNConverter.API.Application.UseCases
{
    public class GetAllConvertedAndOriginalLogsUseCase : IGetAllConvertedAndOriginalLogsUseCase
    {
        private readonly ILogReadOnlyRepository _logReadOnlyRepository;

        public GetAllConvertedAndOriginalLogsUseCase(ILogReadOnlyRepository logReadOnlyRepository)
        {
            _logReadOnlyRepository = logReadOnlyRepository;
        }

        public IList<ResponseConvertedLogJson> Execute()
        {
            var convertedLog = _logReadOnlyRepository.GetAllConvertedLogs();

            if (convertedLog == null) return null;

            var result = convertedLog.Select(log => new ResponseConvertedLogJson
            {
                IdConvertedLog = log.Id,
                CreatedOnConvertedLog = log.CreatedOn,
                PathConvertedLog = log.ConvertedLogPath,
                OriginalLog = new ResponseOriginalLogJson
                {
                    OriginalLogId = log.OriginalLog.Id,
                    CreatedOnOriginalLog = log.OriginalLog.CreatedOn,
                    OriginalLogPath = log.OriginalLog.OriginalLogPath
                }
            }).ToList();

            return result;
        }
    }
}

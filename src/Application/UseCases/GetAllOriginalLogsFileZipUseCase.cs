using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class GetAllOriginalLogsFileZipUseCase : IGetAllOriginalLogsFileZipUseCase
    {
        private readonly ILogDirectoryReadOnlyRepository _logDirectoryReadOnlyRepository;

        public GetAllOriginalLogsFileZipUseCase(ILogDirectoryReadOnlyRepository logDirectoryReadOnlyRepository)
        {
            _logDirectoryReadOnlyRepository = logDirectoryReadOnlyRepository;
        }

        public async Task<byte[]> ExecuteAsync()
        {
            return await _logDirectoryReadOnlyRepository.GetAllOriginalLogs();
        }
    }
}

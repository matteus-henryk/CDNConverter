using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class GetAllConvertedLogsFilesUseCase : IGetAllConvertedLogsFilesUseCase
    {
        private readonly ILogDirectoryReadOnlyRepository _logDirectoryReadOnlyRepository;

        public GetAllConvertedLogsFilesUseCase(ILogDirectoryReadOnlyRepository logDirectoryReadOnlyRepository)
        {
            _logDirectoryReadOnlyRepository = logDirectoryReadOnlyRepository;
        }

        public async Task<byte[]> ExecuteAsync()
        {
            return await _logDirectoryReadOnlyRepository.GetAllConvertedLogs();
        }
    }
}

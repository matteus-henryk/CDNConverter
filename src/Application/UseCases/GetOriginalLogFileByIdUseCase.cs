using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;
using System;
using System.Threading.Tasks;

namespace CDNConverter.API.Application.UseCases
{
    public class GetOriginalLogFileByIdUseCase : IGetOriginalLogFileByIdUseCase
    {
        private readonly ILogDirectoryReadOnlyRepository _logDirectoryReadOnlyRepository;

        public GetOriginalLogFileByIdUseCase(ILogDirectoryReadOnlyRepository logDirectoryReadOnlyRepository)
        {
            _logDirectoryReadOnlyRepository = logDirectoryReadOnlyRepository;
        }

        public async Task<byte[]> ExecuteAsync(Guid id)
        {
            await id.ValidateAsync();

            return await _logDirectoryReadOnlyRepository.GetOriginalLogById(id);
        }
    }
}

using CDNConverter.API.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System;
using CDNConverter.API.Domain.Interfaces.UseCases;
using CDNConverter.API.Extentions;

namespace CDNConverter.API.Application.UseCases
{
    public class GetConvertedLogFileByIdUseCase : IGetConvertedLogFileByIdUseCase
    {
        private readonly ILogDirectoryReadOnlyRepository _logDirectoryReadOnlyRepository;

        public GetConvertedLogFileByIdUseCase(ILogDirectoryReadOnlyRepository logDirectoryReadOnlyRepository)
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

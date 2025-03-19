using System.Threading.Tasks;
using System;
using CDNConverter.API.Shared.Comunication;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IConvertOriginalLogByIdUseCase
    {
        Task<ResponseConvertedLogJson> ExecuteAsync(Guid id);
    }
}

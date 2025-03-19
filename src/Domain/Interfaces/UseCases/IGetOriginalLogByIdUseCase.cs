using System.Threading.Tasks;
using System;
using CDNConverter.API.Shared.Comunication;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetOriginalLogByIdUseCase
    {
        Task<ResponseOriginalLogJson> ExecuteAsync(Guid id);
    }
}

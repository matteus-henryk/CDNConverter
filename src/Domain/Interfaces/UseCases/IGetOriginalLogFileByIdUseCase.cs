using System.Threading.Tasks;
using System;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetOriginalLogFileByIdUseCase
    {
        Task<byte[]> ExecuteAsync(Guid id);
    }
}

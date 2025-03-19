using System;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetConvertedLogFileByIdUseCase
    {
        Task<byte[]> ExecuteAsync(Guid id);
    }
}

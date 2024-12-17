using System.Threading.Tasks;
using System;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetOriginalLogFileByIdService
    {
        Task<byte[]> ExecuteAsync(Guid id);
    }
}

using System;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface ILogDirectoryReadOnlyRepository
    {
        Task<byte[]> GetAllOriginalLogs();
        Task<byte[]> GetOriginalLogById(Guid id);
        Task<byte[]> GetAllConvertedLogs();
        Task<byte[]> GetConvertedLogById(Guid id);
    }
}

using CDNConverter.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface ILogReadOnlyRepository
    {
        IList<OriginalLog> GetAllOriginalsLogs();
        OriginalLog GetOriginalLogById(Guid id);
        IList<ConvertedLog> GetAllConvertedLogs();
        Task<ConvertedLog> GetConvertedLogById(Guid id);
        Task<bool> ExistConvertedLogAsync(Guid id);
    }
}

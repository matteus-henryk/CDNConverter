using CDNConverter.API.Domain.Entities;
using System.Collections.Generic;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        IEnumerable<OriginalLog> GetAllLogs();
        OriginalLog GetLogById(int id);
        void SaveLog(OriginalLog log);
        void SaveConvertedLog(ConvertedLog convertedLog);
    }
}

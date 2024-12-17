using CDNConverter.API.Domain.Entities;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface ILogWriteOnlyRepository
    {
        Task SaveLog(OriginalLog logEntry);
        Task SaveConvertedLog(ConvertedLog convertedLog);
    }
}

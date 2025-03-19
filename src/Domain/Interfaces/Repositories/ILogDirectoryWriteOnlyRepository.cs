using CDNConverter.API.Domain.Entities;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface ILogDirectoryWriteOnlyRepository
    {
        Task<OriginalLog> SaveOriginalLog(byte[] fileBytes);
        Task<(ConvertedLog, byte[])> ConvertAndSaveLog(byte[] fileBytes);
    }
}

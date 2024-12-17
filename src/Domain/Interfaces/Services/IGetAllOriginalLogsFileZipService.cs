using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetAllOriginalLogsFileZipService
    {
        Task<byte[]> ExecuteAsync();
    }
}

using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetAllConvertedLogsFilesService
    {
        Task<byte[]> ExecuteAsync();
    }
}

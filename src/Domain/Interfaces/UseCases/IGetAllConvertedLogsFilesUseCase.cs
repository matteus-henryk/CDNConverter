using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetAllConvertedLogsFilesUseCase
    {
        Task<byte[]> ExecuteAsync();
    }
}

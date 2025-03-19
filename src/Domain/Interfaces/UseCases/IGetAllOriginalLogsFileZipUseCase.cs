using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetAllOriginalLogsFileZipUseCase
    {
        Task<byte[]> ExecuteAsync();
    }
}

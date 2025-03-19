using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IConvertOriginalLogByFileUseCase
    {
        Task<ResponseConvertedLogJson> ExecuteAsync(IFormFile file);
    }
}

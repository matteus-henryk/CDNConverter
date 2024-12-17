using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IConvertOriginalLogByFileService
    {
        Task<ResponseConvertedLogJson> ExecuteAsync(IFormFile file);
    }
}

using System.Threading.Tasks;
using System;
using CDNConverter.API.Shared.Comunication;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetConvertedAndOriginalLogByIdService
    {
        Task<ResponseConvertedLogJson> ExecuteAsync(Guid id);
    }
}

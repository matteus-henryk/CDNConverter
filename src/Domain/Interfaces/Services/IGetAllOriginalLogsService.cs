using CDNConverter.API.Shared.Comunication;
using System.Collections.Generic;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetAllOriginalLogsService
    {
        List<ResponseOriginalLogJson> Execute();
    }
}

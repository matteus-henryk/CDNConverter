using CDNConverter.API.Shared.Comunication;
using System.Collections.Generic;

namespace CDNConverter.API.Domain.Interfaces.Services
{
    public interface IGetAllConvertedAndOriginalLogsService
    {
        IList<ResponseConvertedLogJson> Execute();
    }
}

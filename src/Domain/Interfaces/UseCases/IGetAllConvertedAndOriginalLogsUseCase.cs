using CDNConverter.API.Shared.Comunication;
using System.Collections.Generic;

namespace CDNConverter.API.Domain.Interfaces.UseCases
{
    public interface IGetAllConvertedAndOriginalLogsUseCase
    {
        IList<ResponseConvertedLogJson> Execute();
    }
}

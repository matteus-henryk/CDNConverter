using CDNConverter.API.Domain.Interfaces.Services;
using Moq;

namespace CDNConverted.Tests.Controllers
{
    public class ControllerBaseTest
    {
        internal Mock<IGetConvertedAndOriginalLogByIdUseCase> _getConvertedAndOriginalLogByIdService;
        internal Mock<IGetAllConvertedAndOriginalLogsUseCase> _getAllConvertedAndOriginalLogsService;
        internal Mock<IGetAllConvertedLogsFilesUseCase> _getAllConvertedLogsFilesService;
        internal Mock<IGetAllOriginalLogsUseCase> _getAllOriginalLogsService;
        internal Mock<IGetOriginalLogByIdUseCase> _getOriginalLogByIdService;
        internal Mock<IGetAllOriginalLogsFileZipUseCase> _getAllOriginalLogsFileZipService;
        internal Mock<IGetOriginalLogFileByIdUseCase> _getOriginalLogFileByIdService;
        internal Mock<IConvertOriginalLogByFileUseCase> _convertOriginalLogByFileService;
        internal Mock<IConvertOriginalLogByIdUseCase> _convertOriginalLogByIdService;
        internal Mock<IConvertOriginalLogByFileReturnService> _convertOriginalLogByFileReturnService;
        internal Mock<IConvertOriginalLogByIdFileReturnUseCase> _convertOriginalLogByIdFileReturnService;

        public ControllerBaseTest()
        {
            _getConvertedAndOriginalLogByIdService = new Mock<IGetConvertedAndOriginalLogByIdUseCase>();
            _getAllConvertedAndOriginalLogsService = new Mock<IGetAllConvertedAndOriginalLogsUseCase>();
            _getAllConvertedLogsFilesService = new Mock<IGetAllConvertedLogsFilesUseCase>();
            _getAllOriginalLogsService = new Mock<IGetAllOriginalLogsUseCase>();
            _getOriginalLogByIdService = new Mock<IGetOriginalLogByIdUseCase>();
            _getAllOriginalLogsFileZipService = new Mock<IGetAllOriginalLogsFileZipUseCase>();
            _getOriginalLogFileByIdService = new Mock<IGetOriginalLogFileByIdUseCase>();
            _convertOriginalLogByFileService = new Mock<IConvertOriginalLogByFileUseCase>();
            _convertOriginalLogByIdService = new Mock<IConvertOriginalLogByIdUseCase>();
            _convertOriginalLogByFileReturnService = new Mock<IConvertOriginalLogByFileReturnService>();
            _convertOriginalLogByIdFileReturnService = new Mock<IConvertOriginalLogByIdFileReturnUseCase>();
        }
    }
}

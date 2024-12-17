using CDNConverter.API.Domain.Interfaces.Services;
using Moq;

namespace CDNConverted.Tests.Controllers
{
    public class ControllerBaseTest
    {
        internal Mock<IGetConvertedAndOriginalLogByIdService> _getConvertedAndOriginalLogByIdService;
        internal Mock<IGetAllConvertedAndOriginalLogsService> _getAllConvertedAndOriginalLogsService;
        internal Mock<IGetAllConvertedLogsFilesService> _getAllConvertedLogsFilesService;
        internal Mock<IGetAllOriginalLogsService> _getAllOriginalLogsService;
        internal Mock<IGetOriginalLogByIdService> _getOriginalLogByIdService;
        internal Mock<IGetAllOriginalLogsFileZipService> _getAllOriginalLogsFileZipService;
        internal Mock<IGetOriginalLogFileByIdService> _getOriginalLogFileByIdService;
        internal Mock<IConvertOriginalLogByFileService> _convertOriginalLogByFileService;
        internal Mock<IConvertOriginalLogByIdService> _convertOriginalLogByIdService;
        internal Mock<IConvertOriginalLogByFileReturnService> _convertOriginalLogByFileReturnService;
        internal Mock<IConvertOriginalLogByIdFileReturnService> _convertOriginalLogByIdFileReturnService;

        public ControllerBaseTest()
        {
            _getConvertedAndOriginalLogByIdService = new Mock<IGetConvertedAndOriginalLogByIdService>();
            _getAllConvertedAndOriginalLogsService = new Mock<IGetAllConvertedAndOriginalLogsService>();
            _getAllConvertedLogsFilesService = new Mock<IGetAllConvertedLogsFilesService>();
            _getAllOriginalLogsService = new Mock<IGetAllOriginalLogsService>();
            _getOriginalLogByIdService = new Mock<IGetOriginalLogByIdService>();
            _getAllOriginalLogsFileZipService = new Mock<IGetAllOriginalLogsFileZipService>();
            _getOriginalLogFileByIdService = new Mock<IGetOriginalLogFileByIdService>();
            _convertOriginalLogByFileService = new Mock<IConvertOriginalLogByFileService>();
            _convertOriginalLogByIdService = new Mock<IConvertOriginalLogByIdService>();
            _convertOriginalLogByFileReturnService = new Mock<IConvertOriginalLogByFileReturnService>();
            _convertOriginalLogByIdFileReturnService = new Mock<IConvertOriginalLogByIdFileReturnService>();
        }
    }
}

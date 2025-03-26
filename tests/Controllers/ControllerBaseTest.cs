using CDNConverter.API.Domain.Interfaces.UseCases;
using Moq;

namespace CDNConverted.Tests.Controllers
{
    public class ControllerBaseTest
    {
        internal Mock<IGetConvertedAndOriginalLogByIdUseCase> _getConvertedAndOriginalLogByIdUseCase;
        internal Mock<IGetAllConvertedAndOriginalLogsUseCase> _getAllConvertedAndOriginalLogsUseCase;
        internal Mock<IGetAllConvertedLogsFilesUseCase> _getAllConvertedLogsFilesUseCase;
        internal Mock<IGetAllOriginalLogsUseCase> _getAllOriginalLogsUseCase;
        internal Mock<IGetOriginalLogByIdUseCase> _getOriginalLogByIdUseCase;
        internal Mock<IGetAllOriginalLogsFileZipUseCase> _getAllOriginalLogsFileZipUseCase;
        internal Mock<IGetOriginalLogFileByIdUseCase> _getOriginalLogFileByIdUseCase;
        internal Mock<IConvertOriginalLogByFileUseCase> _convertOriginalLogByFileUseCase;
        internal Mock<IConvertOriginalLogByIdUseCase> _convertOriginalLogByIdUseCase;
        internal Mock<IConvertOriginalLogByFileReturnUseCase> _convertOriginalLogByFileReturnUseCase;
        internal Mock<IConvertOriginalLogByIdFileReturnUseCase> _convertOriginalLogByIdFileReturnUseCase;

        public ControllerBaseTest()
        {
            _getConvertedAndOriginalLogByIdUseCase = new Mock<IGetConvertedAndOriginalLogByIdUseCase>();
            _getAllConvertedAndOriginalLogsUseCase = new Mock<IGetAllConvertedAndOriginalLogsUseCase>();
            _getAllConvertedLogsFilesUseCase = new Mock<IGetAllConvertedLogsFilesUseCase>();
            _getAllOriginalLogsUseCase = new Mock<IGetAllOriginalLogsUseCase>();
            _getOriginalLogByIdUseCase = new Mock<IGetOriginalLogByIdUseCase>();
            _getAllOriginalLogsFileZipUseCase = new Mock<IGetAllOriginalLogsFileZipUseCase>();
            _getOriginalLogFileByIdUseCase = new Mock<IGetOriginalLogFileByIdUseCase>();
            _convertOriginalLogByFileUseCase = new Mock<IConvertOriginalLogByFileUseCase>();
            _convertOriginalLogByIdUseCase = new Mock<IConvertOriginalLogByIdUseCase>();
            _convertOriginalLogByFileReturnUseCase = new Mock<IConvertOriginalLogByFileReturnUseCase>();
            _convertOriginalLogByIdFileReturnUseCase = new Mock<IConvertOriginalLogByIdFileReturnUseCase>();
        }
    }
}

using CDNConverter.API.Domain.Interfaces.Repositories;
using Moq;

namespace CDNConverted.Tests.Application
{
    public class UseCasesBaseTests
    {
        internal readonly Mock<ILogReadOnlyRepository> _logReadOnlyRepository;

        public UseCasesBaseTests()
        {
            _logReadOnlyRepository = new Mock<ILogReadOnlyRepository>();
        }
    }
}

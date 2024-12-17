using CDNConverter.API.Domain.Interfaces.Repositories;
using Moq;

namespace CDNConverted.Tests.Application
{
    public class ServicesBaseTests
    {
        internal readonly Mock<ILogReadOnlyRepository> _logReadOnlyRepository;

        public ServicesBaseTests()
        {
            _logReadOnlyRepository = new Mock<ILogReadOnlyRepository>();
        }
    }
}

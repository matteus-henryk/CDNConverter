using CDNConverter.API.Application.Services;
using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Shared.Comunication;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CDNConverted.Tests.Application
{
    public class GetAllOriginalLogsServiceTest : ServicesBaseTests
    {
        private GetAllOriginalLogsUseCase _service;

        [Fact]
        public void When_GetAllOriginalLogsServiceTest_Should_Return_List()
        {
            _service = new GetAllOriginalLogsUseCase(_logReadOnlyRepository.Object);

            _logReadOnlyRepository.Setup(repo => repo.GetAllOriginalsLogs())
                .Returns(new List<OriginalLog>());

            var result = _service.Execute();

            result.Should().BeOfType<List<ResponseOriginalLogJson>>();
        }

        [Fact]
        public void When_GetAllOriginalLogsServiceTest_Should_Return_Null()
        {
            _service = new GetAllOriginalLogsUseCase(_logReadOnlyRepository.Object);

            _logReadOnlyRepository.Setup(repo => repo.GetAllOriginalsLogs())
                .Returns((List<OriginalLog>)null);

            var result = _service.Execute();

            result.Should().BeNullOrEmpty();
        }
    }
}

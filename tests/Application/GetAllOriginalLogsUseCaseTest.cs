using CDNConverter.API.Application.UseCases;
using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Shared.Comunication;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CDNConverted.Tests.Application
{
    public class GetAllOriginalLogsUseCaseTest : UseCasesBaseTests
    {
        private GetAllOriginalLogsUseCase _useCase;

        [Fact]
        public void When_GetAllOriginalLogsUseCaseTest_Should_Return_List()
        {
            _useCase = new GetAllOriginalLogsUseCase(_logReadOnlyRepository.Object);

            _logReadOnlyRepository.Setup(repo => repo.GetAllOriginalsLogs())
                .Returns(new List<OriginalLog>());

            var result = _useCase.Execute();

            result.Should().BeOfType<List<ResponseOriginalLogJson>>();
        }

        [Fact]
        public void When_GetAllOriginalLogsUseCaseTest_Should_Return_Null()
        {
            _useCase = new GetAllOriginalLogsUseCase(_logReadOnlyRepository.Object);

            _logReadOnlyRepository.Setup(repo => repo.GetAllOriginalsLogs())
                .Returns((List<OriginalLog>)null);

            var result = _useCase.Execute();

            result.Should().BeNullOrEmpty();
        }
    }
}

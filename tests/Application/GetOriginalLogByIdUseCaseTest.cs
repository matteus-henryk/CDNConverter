using CDNConverter.API.Application.UseCases;
using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Shared.Comunication;
using CDNConverter.API.Shared.Exceptions.ExceptionsBase;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CDNConverted.Tests.Application
{
    public class GetOriginalLogByIdUseCaseTest : UseCasesBaseTests
    {
        private GetOriginalLogByIdUseCase _useCase;

        [Fact]
        public async Task When_GetOriginalLogByIdUseCase_Rerturn_Value()
        {
            _useCase = new GetOriginalLogByIdUseCase(_logReadOnlyRepository.Object);

            var id = Guid.NewGuid();

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns(new OriginalLog());

            var result = await _useCase.ExecuteAsync(id);

            result.Should().BeOfType<ResponseOriginalLogJson>();
        }

        [Fact]
        public async Task When_GetOriginalLogByIdUseCase_Rerturn_Null()
        {
            _useCase = new GetOriginalLogByIdUseCase(_logReadOnlyRepository.Object);

            var id = Guid.NewGuid();

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns((OriginalLog)null);

            var result = await _useCase.ExecuteAsync(id);

            result.Should().BeNull();
        }

        [Fact]
        public async Task When_GetOriginalLogByIdUseCase_Id_Is_Empty()
        {
            _useCase = new GetOriginalLogByIdUseCase(_logReadOnlyRepository.Object);

            var id = Guid.Empty;

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns((OriginalLog)null);

            Func<Task> result = async () => await _useCase.ExecuteAsync(id);

            await result.Should().ThrowAsync<BadRequestException>();
        }
    }
}

using CDNConverter.API.Application.Services;
using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Shared.Comunication;
using CDNConverter.API.Shared.Exceptions.ExceptionsBase;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CDNConverted.Tests.Application
{
    public class GetOriginalLogByIdServiceTest : ServicesBaseTests
    {
        private GetOriginalLogByIdService _service;

        [Fact]
        public async Task When_GetOriginalLogByIdService_Rerturn_Value()
        {
            _service = new GetOriginalLogByIdService(_logReadOnlyRepository.Object);

            var id = Guid.NewGuid();

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns(new OriginalLog());

            var result = await _service.ExecuteAsync(id);

            result.Should().BeOfType<ResponseOriginalLogJson>();
        }

        [Fact]
        public async Task When_GetOriginalLogByIdService_Rerturn_Null()
        {
            _service = new GetOriginalLogByIdService(_logReadOnlyRepository.Object);

            var id = Guid.NewGuid();

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns((OriginalLog)null);

            var result = await _service.ExecuteAsync(id);

            result.Should().BeNull();
        }

        [Fact]
        public async Task When_GetOriginalLogByIdService_Id_Is_Empty()
        {
            _service = new GetOriginalLogByIdService(_logReadOnlyRepository.Object);

            var id = Guid.Empty;

            _logReadOnlyRepository.Setup(repo => repo.GetOriginalLogById(id))
                .Returns((OriginalLog)null);

            Func<Task> result = async () => await _service.ExecuteAsync(id);

            await result.Should().ThrowAsync<BadRequestException>();
        }
    }
}

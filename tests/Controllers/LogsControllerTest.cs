using CDNConverter.API.Controllers;
using CDNConverter.API.Shared.Comunication;
using CDNConverter.API.Shared.Exceptions;
using CDNConverter.API.Shared.Exceptions.ExceptionsBase;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CDNConverted.Tests.Controllers
{
    public class LogsControllerTest : ControllerBaseTest
    {
        private LogsController _controller;

        #region GetAllOriginalSavedLogs

        [Fact]
        public void When_GetAllOriginalSavedLogs_Should_Be_Ok()
        {
            _controller = new LogsController();

            _getAllOriginalLogsUseCase.Setup(service => service.Execute())
                .Returns(new List<ResponseOriginalLogJson>());

            var result = _controller.GetAllOriginalSavedLogs(_getAllOriginalLogsUseCase.Object);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void When_GetAllOriginalSavedLogs_UseCase_Return_Null_Should_Be_NotFound()
        {
            _controller = new LogsController();

            _getAllOriginalLogsUseCase.Setup(service => service.Execute())
                .Returns((List<ResponseOriginalLogJson>)null);

            var result = _controller.GetAllOriginalSavedLogs(_getAllOriginalLogsUseCase.Object);

            result.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        #endregion

        #region GetOriginalLogById

        [Fact]
        public async Task When_GetOriginalLogById_Return_Value_Should_Be_Ok()
        {
            _controller = new LogsController();
            var id = Guid.NewGuid();

            _getOriginalLogByIdUseCase.Setup(service => service.ExecuteAsync(id))
                .ReturnsAsync(new ResponseOriginalLogJson());

            var result =  await _controller.GetOriginalLogById(_getOriginalLogByIdUseCase.Object, id);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_GetOriginalLogById_Return_Null_Should_Be_NotFound()
        {
            _controller = new LogsController();
            var id = Guid.NewGuid();

            _getOriginalLogByIdUseCase.Setup(service => service.ExecuteAsync(id))
                .ReturnsAsync((ResponseOriginalLogJson)null);

            var result = await _controller.GetOriginalLogById(_getOriginalLogByIdUseCase.Object, id);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task When_GetOriginalLogById_Id_Is_Empyt_Should_Be_BadRequest()
        {
            _controller = new LogsController();
            var id = Guid.Empty;

            _getOriginalLogByIdUseCase.Setup(service => service.ExecuteAsync(id))
                .ThrowsAsync(new BadRequestException(new List<string> { ResourceMessagesExceptions.EMPYT_IDENTIFIER }));

            Func<Task> result = async () => await _controller.GetOriginalLogById(_getOriginalLogByIdUseCase.Object, id);

            await result.Should().ThrowAsync<BadRequestException>();
        }

        #endregion


    }
}

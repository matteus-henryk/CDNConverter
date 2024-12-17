using CDNConverter.API.Shared.Exceptions.ExceptionsBase;
using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CDNConverter.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CDNConverterException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessages));
            }
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Result = new ObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
    }
}

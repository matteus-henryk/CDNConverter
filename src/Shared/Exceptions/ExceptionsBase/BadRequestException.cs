using System.Collections.Generic;

namespace CDNConverter.API.Shared.Exceptions.ExceptionsBase
{
    public class BadRequestException : CDNConverterException
    {
        public BadRequestException(IList<string> errorsMessages) : base(string.Empty)
        {
            ErrorsMessages = errorsMessages;
        }

        public IList<string> ErrorsMessages { get; set; }
    }
}

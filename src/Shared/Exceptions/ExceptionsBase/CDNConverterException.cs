using System;

namespace CDNConverter.API.Shared.Exceptions.ExceptionsBase
{
    public class CDNConverterException : SystemException
    {
        public CDNConverterException(string message) : base(message) { }
    }
}

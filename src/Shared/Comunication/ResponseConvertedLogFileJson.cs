using System;

namespace CDNConverter.API.Shared.Comunication
{
    public class ResponseConvertedLogFileJson
    {
        public Guid Id { get; set; }
        public byte[] ConvertedLogFile { get; set; }
    }
}

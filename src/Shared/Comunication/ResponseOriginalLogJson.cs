using System;

namespace CDNConverter.API.Shared.Comunication
{
    public class ResponseOriginalLogJson
    {
        public Guid OriginalLogId { get; set; }
        public DateTime CreatedOnOriginalLog { get; set; }
        public string OriginalLogPath { get; set; }
    }
}

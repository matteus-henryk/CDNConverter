using System;

namespace CDNConverter.API.Domain.Entities
{
    public class ConvertedLog
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string ConvertedLogPath { get;  set; }
        public Guid OriginalLogId { get; set; }
        public OriginalLog OriginalLog { get; set; }
    }
}

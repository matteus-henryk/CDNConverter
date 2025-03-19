using System;

namespace CDNConverter.API.Domain.Entities
{
    public class OriginalLog
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string OriginalLogPath { get; set; }
    }
}

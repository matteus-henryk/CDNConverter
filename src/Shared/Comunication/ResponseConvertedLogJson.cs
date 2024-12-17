using System;

namespace CDNConverter.API.Shared.Comunication
{
    public class ResponseConvertedLogJson
    {
        public Guid IdConvertedLog { get; set; }
        public DateTime CreatedOnConvertedLog { get; set; }
        public string PathConvertedLog { get; set; }
        public ResponseOriginalLogJson OriginalLog { get; set; }
    }

}

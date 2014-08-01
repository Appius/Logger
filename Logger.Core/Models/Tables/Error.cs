using System;

namespace Logger.Core.Models.Tables
{
    public class Error
    {
        public int Id { get; set; } // Id (Primary key)
        public string ApiKey { get; set; } // ApiKey
        public string Name { get; set; } // Name
        public DateTime DateTime { get; set; } // DateTime
        public string Message { get; set; } // Message
        public string HelpLink { get; set; } // HelpLink
        public string Data { get; set; } // Data
        public int HResult { get; set; } // HResult
        public string Source { get; set; } // Source
        public string TargetSite { get; set; } // TargetSite
        public string StackTrace { get; set; } // StackTrace
        public string Postdata { get; set; } // Postdata
        public string Useragent { get; set; } // Useragent
        public string Referrer { get; set; } // Referrer
        public int OsId { get; set; } // OsId
        public int BrowserId { get; set; } // BrowserId

        // Foreign keys
        public virtual Browser Browser { get; set; } // FK_Errors_Browsers
        public virtual OS OS { get; set; } // FK_Errors_OSs
    }
}
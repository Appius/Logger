using System;

namespace Logger.Core.Models
{
    [Serializable]
    public class ErrorModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Os { get; set; }
        public string Browser { get; set; }

        public string Message { get; set; }
        public string HelpLink { get; set; }
        public string Data { get; set; }
        public int HResult { get; set; }
        public string Source { get; set; }
        public string Targetsite { get; set; }
        public string Stacktrace { get; set; }
        public string Postdata { get; set; }
        public string Useragent { get; set; }
        public string Referrer { get; set; }
    }
}
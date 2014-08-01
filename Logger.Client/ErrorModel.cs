using System;

namespace Logger.Client
{
    [Serializable]
    public class ErrorModel
    {
        public ErrorModel(string key, string name, string os, string browser,
                          string message, string helpLink, string data, int hResult,
                          string source, string targetsite, string stacktrace, string postdata, string useragent, string referrer)
        {
            Key = key;
            Name = name;
            Os = os;
            Browser = browser;

            Message = message;
            HelpLink = helpLink;
            Data = data;
            HResult = hResult;
            Source = source;
            Targetsite = targetsite;
            Stacktrace = stacktrace;
            Postdata = postdata;
            Useragent = useragent;
            Referrer = referrer;
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Os { get; private set; }
        public string Browser { get; private set; }

        public string Message { get; private set; }
        public string HelpLink { get; private set; }
        public string Data { get; private set; }
        public int HResult { get; private set; }
        public string Source { get; private set; }
        public string Targetsite { get; private set; }
        public string Stacktrace { get; private set; }
        public string Postdata { get; private set; }
        public string Useragent { get; private set; }
        public string Referrer { get; private set; }
    }
}
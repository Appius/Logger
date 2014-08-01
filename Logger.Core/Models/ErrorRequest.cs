using System;

namespace Logger.Core.Models
{
    public class ErrorRequest
    {
        private ErrorTypeRequest _errorTypeRequest = ErrorTypeRequest.Current;
        public int Id { get; set; }
        public string ApiKey { get; set; }

        public ErrorTypeRequest ErrorTypeRequest
        {
            get { return _errorTypeRequest; }
            set { _errorTypeRequest = value; }
        }
    }

    public enum ErrorTypeRequest
    {
        Current,
        Previous,
        Next
    }
}
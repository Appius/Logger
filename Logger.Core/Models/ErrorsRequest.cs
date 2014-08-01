using System;

namespace Logger.Core.Models
{
    public class ErrorsRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool OrderByDescending { get; set; }
        public string ApiKey { get; set; }
    }
}
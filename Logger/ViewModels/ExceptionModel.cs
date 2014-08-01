using System;
using Logger.Core.Models;
using Logger.Core.Models.Tables;

namespace Logger.ViewModels
{
    public class ExceptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public int OsId { get; set; }
        public int BrowserId { get; set; }

        public Browser Browser { get; set; }
        public OS OS { get; set; }
    }
}
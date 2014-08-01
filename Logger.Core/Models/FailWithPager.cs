using System;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models
{
    public class FailWithPager
    {
        public FailWithPager(Error error, int? prev, int? next)
        {
            Error = error;
            Next = next;
            Prev = prev;
        }

        public Error Error { set; get; }
        public int? Prev { set; get; }
        public int? Next { set; get; }
    }
}
using System;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Abstract
{
    public interface IBrowserRepository
    {
        Browser Merge(string browser);
    }
}
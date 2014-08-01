using System;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Abstract
{
    public interface IOsRepository
    {
        OS Merge(string os);
    }
}
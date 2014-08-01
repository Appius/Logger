using System;
using System.Collections.Generic;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Abstract
{
    public interface ISiteRepository
    {
        UserProfile GetUserByApiKey(string key);
        Site Get(int id);
        Site Get(string apikey);
        IEnumerable<Site> GetAllByUserId(int userId);
        IEnumerable<Site> GetAll();
        int Add(Site site);
        int Toggle(Site site);
        int Remove(Site site);
        int Remove(int siteid);
    }
}
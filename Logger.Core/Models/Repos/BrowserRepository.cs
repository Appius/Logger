using System;
using System.Linq;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Repos
{
    public class BrowserRepository : RepositoryBase, IBrowserRepository
    {
        public Browser Merge(string browser)
        {
            var firstOrDefault = Db.Browsers.FirstOrDefault(item => item.Name == browser);
            if (firstOrDefault == null)
            {
                Db.Browsers.Add(new Browser {Name = browser});
                Db.SaveChanges();

                firstOrDefault = Db.Browsers.FirstOrDefault(item => item.Name == browser);
            }
            return firstOrDefault;
        }
    }
}
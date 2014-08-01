using System;
using System.Linq;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Repos
{
    public class OsRepository : RepositoryBase, IOsRepository
    {
        public OS Merge(string os)
        {
            var firstOrDefault = Db.OSs.FirstOrDefault(item => item.Name == os);
            if (firstOrDefault == null)
            {
                Db.OSs.Add(new OS { Name = os });
                Db.SaveChanges();

                firstOrDefault = Db.OSs.FirstOrDefault(item => item.Name == os);
            }
            return firstOrDefault;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Repos
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserProfile Get(int id)
        {
            return Db.UserProfiles.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return Db.UserProfiles.OrderByDescending(item => item.Id);
        }
    }
}
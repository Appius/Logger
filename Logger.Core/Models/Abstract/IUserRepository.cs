using System;
using System.Collections.Generic;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Abstract
{
    public interface IUserRepository
    {
        UserProfile Get(int id);
        IEnumerable<UserProfile> GetAll();
    }
}
using System;
using System.Data.Entity;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Abstract
{
    public interface IDBContext : IDisposable
    {
        IDbSet<Browser> Browsers { get; set; } // Browsers
        IDbSet<Error> Errors { get; set; } // Errors
        IDbSet<OS> OSs { get; set; } // OSs
        IDbSet<Site> Sites { get; set; } // Sites
        IDbSet<UserProfile> UserProfiles { get; set; } // UserProfile

        int SaveChanges();
    }
}
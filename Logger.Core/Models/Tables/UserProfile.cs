using System;
using System.Collections.Generic;

namespace Logger.Core.Models.Tables
{
    public class UserProfile
    {
        public UserProfile()
        {
            Sites = new List<Site>();
        }

        public int Id { get; set; } // Id (Primary key)
        public string Email { get; set; } // Email
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public DateTime Birthday { get; set; } // Birthday

        // Reverse navigation
        public virtual ICollection<Site> Sites { get; set; } // Sites.FK_Sites_Users
    }
}
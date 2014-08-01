using System;

namespace Logger.Core.Models.Tables
{
    public class Site
    {
        public Site()
        {
            IsBlocked = false;
        }

        public int Id { get; set; } // Id (Primary key)
        public int UserId { get; set; } // UserId
        public string ApiKey { get; set; } // ApiKey
        public bool IsBlocked { get; set; } // IsBlocked
        public string Url { get; set; } // Url
        public string Name { get; set; } // Name
        public string Description { get; set; } // Description

        // Foreign keys
        public virtual UserProfile UserProfile { get; set; } // FK_Sites_Users
    }
}
using System;
using System.Collections.Generic;

namespace Logger.Core.Models.Tables
{
    public class Browser
    {
        public Browser()
        {
            Errors = new List<Error>();
        }

        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name

        // Reverse navigation
        public virtual ICollection<Error> Errors { get; set; } // Errors.FK_Errors_Browsers
    }
}
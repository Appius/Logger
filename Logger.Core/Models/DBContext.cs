using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Configuration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models
{
    public class DBContext : DbContext, IDBContext
    {
        static DBContext()
        {
            Database.SetInitializer<DBContext>(null);
        }

        public DBContext()
            : base("Name=AzureConnection")
        {
        }

        public DBContext(string connectionString)
            : base(connectionString)
        {
        }

        public DBContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public IDbSet<Browser> Browsers { get; set; } // Browsers
        public IDbSet<Error> Errors { get; set; } // Errors
        public IDbSet<OS> OSs { get; set; } // OSs
        public IDbSet<Site> Sites { get; set; } // Sites
        public IDbSet<UserProfile> UserProfiles { get; set; } // UserProfile

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BrowserConfiguration());
            modelBuilder.Configurations.Add(new ErrorConfiguration());
            modelBuilder.Configurations.Add(new OSConfiguration());
            modelBuilder.Configurations.Add(new SiteConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new BrowserConfiguration(schema));
            modelBuilder.Configurations.Add(new ErrorConfiguration(schema));
            modelBuilder.Configurations.Add(new OSConfiguration(schema));
            modelBuilder.Configurations.Add(new SiteConfiguration(schema));
            modelBuilder.Configurations.Add(new UserProfileConfiguration(schema));
            return modelBuilder;
        }
    }
}
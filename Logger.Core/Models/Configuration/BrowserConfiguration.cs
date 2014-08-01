using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Configuration
{
    internal class BrowserConfiguration : EntityTypeConfiguration<Browser>
    {
        public BrowserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Browsers");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
        }
    }
}
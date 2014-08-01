using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Configuration
{
    internal class OSConfiguration : EntityTypeConfiguration<OS>
    {
        public OSConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".OSs");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
        }
    }
}
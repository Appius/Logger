using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Configuration
{
    internal class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserProfile");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(56);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(32);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(32);
            Property(x => x.Birthday).HasColumnName("Birthday").IsRequired();
        }
    }
}
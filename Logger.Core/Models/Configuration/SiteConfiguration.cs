using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Configuration
{
    internal class SiteConfiguration : EntityTypeConfiguration<Site>
    {
        public SiteConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Sites");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.ApiKey).HasColumnName("ApiKey").IsRequired().HasMaxLength(32);
            Property(x => x.IsBlocked).HasColumnName("IsBlocked").IsRequired();
            Property(x => x.Url).HasColumnName("Url").IsRequired().HasMaxLength(255);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(1024);

            // Foreign keys
            HasRequired(a => a.UserProfile).WithMany(b => b.Sites).HasForeignKey(c => c.UserId); // FK_Sites_Users
        }
    }
}
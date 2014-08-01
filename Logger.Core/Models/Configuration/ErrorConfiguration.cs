using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Configuration
{
    internal class ErrorConfiguration : EntityTypeConfiguration<Error>
    {
        public ErrorConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Errors");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ApiKey).HasColumnName("ApiKey").IsRequired().HasMaxLength(32);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(x => x.DateTime).HasColumnName("DateTime").IsRequired();
            Property(x => x.Message).HasColumnName("Message").IsRequired().HasMaxLength(255);
            Property(x => x.HelpLink).HasColumnName("HelpLink").IsOptional().HasMaxLength(255);
            Property(x => x.Data).HasColumnName("Data").IsOptional();
            Property(x => x.HResult).HasColumnName("HResult").IsRequired();
            Property(x => x.Source).HasColumnName("Source").IsOptional().HasMaxLength(255);
            Property(x => x.TargetSite).HasColumnName("TargetSite").IsOptional().HasMaxLength(255);
            Property(x => x.StackTrace).HasColumnName("StackTrace").IsOptional();
            Property(x => x.Postdata).HasColumnName("Postdata").IsOptional();
            Property(x => x.Useragent).HasColumnName("Useragent").IsOptional().HasMaxLength(255);
            Property(x => x.Referrer).HasColumnName("Referrer").IsOptional().HasMaxLength(255);
            Property(x => x.OsId).HasColumnName("OsId").IsRequired();
            Property(x => x.BrowserId).HasColumnName("BrowserId").IsRequired();

            // Foreign keys
            HasRequired(a => a.OS).WithMany(b => b.Errors).HasForeignKey(c => c.OsId); // FK_Errors_OSs
            HasRequired(a => a.Browser).WithMany(b => b.Errors).HasForeignKey(c => c.BrowserId); // FK_Errors_Browsers
        }
    }
}
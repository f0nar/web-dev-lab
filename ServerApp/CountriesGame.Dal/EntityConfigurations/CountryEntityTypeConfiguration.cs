using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.CapitalName)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(c => c.FlagPath)
                .HasMaxLength(260)
                .IsRequired();

            builder.Property(c => c.CoatPath)
                .HasMaxLength(260)
                .IsRequired();
                
            builder.Property(c => c.AnthemPath)
                .HasMaxLength(260)
                .IsRequired();

            builder.HasMany(c => c.Links)
                .WithOne(l => l.Country)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
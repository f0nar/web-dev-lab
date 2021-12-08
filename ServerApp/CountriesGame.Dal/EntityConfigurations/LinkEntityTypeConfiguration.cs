using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class LinkEntityTypeConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.Property(l => l.Url)
                .HasMaxLength(2048)
                .IsRequired();

            builder.Property(l => l.Description)
                .HasMaxLength(1000);
        }
    }
}
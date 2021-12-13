using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class OptionEntityTypeConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.Property(o => o.Content)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.MatchContent)
                .HasMaxLength(100);
        }
    }
}
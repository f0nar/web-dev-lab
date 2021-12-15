using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class SubmittedOptionEntityTypeConfiguration : IEntityTypeConfiguration<SubmittedOption>
    {
        public void Configure(EntityTypeBuilder<SubmittedOption> builder)
        {
            builder.Property(so => so.MatchContent)
                .HasMaxLength(100);
        }
    }
}
using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class SubmittedQuestionEntityTypeConfiguration : IEntityTypeConfiguration<SubmittedQuestion>
    {
        public void Configure(EntityTypeBuilder<SubmittedQuestion> builder)
        {
            builder.HasMany(sq => sq.SubmittedOptions)
                .WithOne(o => o.SubmittedQuestion)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
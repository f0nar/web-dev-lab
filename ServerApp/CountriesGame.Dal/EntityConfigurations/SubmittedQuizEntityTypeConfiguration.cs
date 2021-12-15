using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class SubmittedQuizEntityTypeConfiguration : IEntityTypeConfiguration<SubmittedQuiz>
    {
        public void Configure(EntityTypeBuilder<SubmittedQuiz> builder)
        {
            builder.HasMany(sq => sq.SubmittedQuestions)
                .WithOne(sq => sq.SubmittedQuiz)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
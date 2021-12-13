using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class QuizEntityTypeConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.Property(q => q.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(q => q.Description)
                .HasMaxLength(1000);

            builder.HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
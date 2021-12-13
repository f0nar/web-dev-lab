using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Content)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(q => q.Type)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(q => q.Points)
                .HasDefaultValue(0);

            builder.HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
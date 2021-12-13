using CountriesGame.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountriesGame.Dal.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(u => u.Head)
                .WithMany(u => u.SubUsers)
                .HasForeignKey(u => u.HeadId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CountriesGame.Dal.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CountryEntityTypeConfiguration())
                .ApplyConfiguration(new LinkEntityTypeConfiguration())
                .ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new QuizEntityTypeConfiguration())
                .ApplyConfiguration(new QuestionEntityTypeConfiguration())
                .ApplyConfiguration(new OptionEntityTypeConfiguration());
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Link> Links { get; set; } 

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }
    }
}
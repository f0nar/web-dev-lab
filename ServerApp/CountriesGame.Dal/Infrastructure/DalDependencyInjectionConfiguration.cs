using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.FileReaders;
using CountriesGame.Dal.FileReaders.Interfaces;
using CountriesGame.Dal.UnitOfWorks;
using CountriesGame.Dal.UnitOfWorks.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesGame.Dal.Infrastructure
{
    public static class DalDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IFileReader, FileReader>();

            return services;
        }
    }
}
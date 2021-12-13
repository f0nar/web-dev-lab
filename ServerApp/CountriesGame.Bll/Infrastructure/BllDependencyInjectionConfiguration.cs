using Microsoft.Extensions.Configuration;
using CountriesGame.Dal.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Bll.Services;

namespace CountriesGame.Bll.Infrastructure
{
    public static class BllDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureBll(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureDal(configuration);

            services.AddAutoMapper(typeof(BetweenDalAndBllMapperProfile));

            services.AddTransient<IDataSeeder, DataSeeder>();

            services.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ILinkService, LinkService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesGame.Bll.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CountriesGame.Web.Extensions;
using CountriesGame.Web.Middlewares;

namespace CountriesGame.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureBll(_configuration);

            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddCors();

            services.ConfigureSwagger();

            services.ConfigureAuthentication(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ApiExceptionHandlingMiddleware>();
            }
            // TODO: Comment this line
            app.UseMiddleware<ApiExceptionHandlingMiddleware>();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "CountriesGame API");
            });

            if ((_configuration["INITDB"] ?? "false") == "true")
            {
                seeder.SeedDataAsync().Wait();
            }

        }
    }
}

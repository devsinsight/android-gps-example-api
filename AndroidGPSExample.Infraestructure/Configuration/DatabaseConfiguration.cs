using AndroidGPSExample.Domain.Contract;
using AndroidGPSExample.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AndroidGPSExample.Repository.Configuration
{
    public class DatabaseConfiguration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            Action<SqlServerDbContextOptionsBuilder> action = (options) =>
            {
                //options.UseRelationalNulls();
            };

            services
             .AddDbContext<GeoLocationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), action), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}

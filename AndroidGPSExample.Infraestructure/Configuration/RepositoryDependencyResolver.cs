using AndroidGPSExample.Domain.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace AndroidGPSExample.Repository.Configuration
{
    public class RepositoryDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGeoLocationRepository, GeoLocationRepository>();
        }
    }
}

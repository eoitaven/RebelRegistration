using Microsoft.Extensions.DependencyInjection;
using RebelRegistration.Repositories;

namespace RebelRegistration.Extensions.ServiceCollection
{
    public static class RepositoriesConfigurationExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IPlanetRepository, PlanetRepository>()
                .AddTransient<IPlanetLogRepository, PlanetLogRepository>();
            return services;
        }
    }
}

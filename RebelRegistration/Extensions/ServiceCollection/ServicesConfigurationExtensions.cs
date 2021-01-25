using Microsoft.Extensions.DependencyInjection;
using RebelRegistration.Services;

namespace RebelRegistration.Extensions.ServiceCollection
{
    public static class ServicesConfigurationExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IRebelRegisterService, RebelRegisterService>();
            return services;
        }
    }
}

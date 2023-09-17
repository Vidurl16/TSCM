using Microsoft.Extensions.DependencyInjection;
using API.Services;
using API.Interfaces;

namespace API.Extensions
{
    public static class ServiceServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}

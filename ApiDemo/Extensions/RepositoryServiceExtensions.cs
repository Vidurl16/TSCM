using Microsoft.Extensions.DependencyInjection;
using API.Repository;
using API.Interfaces.RepositoryInterfaces;

namespace API.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}

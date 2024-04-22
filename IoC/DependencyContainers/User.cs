using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;

namespace IoC.DependencyContainers
{
    public static class User
    {
        public static IServiceCollection AddSpiderWatcherUserDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddUserRepositories(configuration);
            services.AddUserServices();
            services.AddUserPresenters();

            return services;
        }
    }
}

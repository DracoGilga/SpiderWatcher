using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;

namespace IoC.DependencyContainers
{
    public static class Content
    {
        public static IServiceCollection AddSpiderWatcherContentDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddContentRepositories(configuration);
            services.AddContentServices();
            services.AddContentPresenters();

            return services;
        }
    }
}

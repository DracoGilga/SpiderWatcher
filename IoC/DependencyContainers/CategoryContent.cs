using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;

namespace IoC.DependencyContainers
{
    public static class CategoryContent
    {
        public static IServiceCollection AddSpiderWatcherCategoryContentDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddCategoryContentRepositories(configuration);
            services.AddCategoryContentServices();
            services.AddCategoryContentPresenters();

            return services;
        }
    }
}

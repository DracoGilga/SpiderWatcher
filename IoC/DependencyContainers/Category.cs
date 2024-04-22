using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;

namespace IoC.DependencyContainers
{
    public static class Category
    {
        public static IServiceCollection AddSpiderWatcherCategoryDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddCategoryRepositories(configuration);
            services.AddCategoryServices();
            services.AddCategoryPresenters();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters;
using RepositoryEFCore;
using UseCases;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSpiderWatcherDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddPresenters();

            return services;
        }
    }
}

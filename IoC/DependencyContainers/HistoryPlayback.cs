using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;

namespace IoC.DependencyContainers
{
    public static class HistoryPlayback
    {
        public static IServiceCollection AddSpiderWatcherHistoryPlaybackDependencies(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddHistoryPlaybackRepositories(configuration);
            services.AddHistoryPlaybackServices();
            services.AddHistoryPlaybackPresenters();

            return services;
        }
    }
}

using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace RepositoryEFCore.DependencyContainers
{
    public static class Content
    {
        public static IServiceCollection AddContentRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SpiderWatcherContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SpiderWatcherMSQL")));

            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

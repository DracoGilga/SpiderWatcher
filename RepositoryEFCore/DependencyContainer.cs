using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace RepositoryEFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<SpiderWatcherContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SpiderWatcherMSQL")));
            
            services.AddScoped<ICategoryContentRepository, CategoryContentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IHistoryPlaybackRepository, HistoryPlaybackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IValidationRepository, ValidationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

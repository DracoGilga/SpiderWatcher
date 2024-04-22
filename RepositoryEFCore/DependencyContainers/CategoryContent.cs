using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace RepositoryEFCore.DependencyContainers
{
    public static class CategoryContent
    {
        public static IServiceCollection AddCategoryContentRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SpiderWatcherContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SpiderWatcherMSQL")));

            services.AddScoped<ICategoryContentRepository, CategoryContentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

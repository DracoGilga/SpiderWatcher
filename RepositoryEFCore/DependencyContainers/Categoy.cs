using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace RepositoryEFCore.DependencyContainers
{
    public static class Categoy
    {
        public static IServiceCollection AddCategoryRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SpiderWatcherContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SpiderWatcherMSQL")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

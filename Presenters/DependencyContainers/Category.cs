using Microsoft.Extensions.DependencyInjection;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Outputs;

namespace Presenters.DependencyContainers
{
    public static class Category
    {
        public static IServiceCollection AddCategoryPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateCategoryOutputPort,
                CreateCategoryPresenter>();
            services.AddScoped<IDeleteCategoryOutputPort,
                DeleteCategoryPresenter>();
            services.AddScoped<IReadAllCategoryOutputPort,
                ReadAllCategoryPresenter>();
            services.AddScoped<IReadCategoryOutputPort,
                ReadCategoryPresenter>();
            services.AddScoped<IUpdateCategoryOutputPort,
                UpdateCategoryPresenter>();

            return services;
        }
    }
}

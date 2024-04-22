using Microsoft.Extensions.DependencyInjection;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.DependencyContainers
{
    public static class CategoryContent
    {
        public static IServiceCollection AddCategoryContentPresenters(
                       this IServiceCollection services)
        {
            services.AddScoped<ICreateCategoryContentOutputPort,
                CreateCategoryContentPresenter>();
            services.AddScoped<IDeleteCategoryContentOutputPort,
                DeleteCategoryContentPresenter>();
            services.AddScoped<IReadAllCategoryContentOutputPort,
                ReadAllCategoryContentPresenter>();
            services.AddScoped<IReadCategoryContentOutputPort,
                ReadCategoryContentPresenter>();
            services.AddScoped<IUpdateCategoryContentOutputPort,
                UpdateCategoryContentPresenter>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using UseCases.CategoryContentUC;
using UseCasesPort.CategoryContentPorts.Inputs;

namespace UseCases.DependencyContainers
{
    public static class CategoryContent
    {
        public static IServiceCollection AddCategoryContentServices(this IServiceCollection services)
        {
            services.AddTransient
                <ICreateCategoryContentInputPort, CreateCategoryContentInteractor>();
            services.AddTransient
                <IDeleteCategoryContentInputPort, DeleteCategoryContentInteractor>();
            services.AddTransient
                <IReadAllCategoryContentInputPort, ReadAllCategoryContentInteractor>();
            services.AddTransient
                <IReadCategoryContentInputPort, ReadCategoryContentInteractor>();
            services.AddTransient
                <IUpdateCategoryContentInputPort, UpdateCategoryContentInteractor>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using UseCases.CategoryUC;
using UseCasesPort.CategoryPorts.Inputs;

namespace UseCases.DependencyContainers
{
    public static class Category
    {
        public static IServiceCollection AddCategoryServices(this IServiceCollection services)
        {
            services.AddTransient
                <ICreateCategoryInputPort, CreateCategoryInteractor>();
            services.AddTransient
                <IDeleteCategoryInputPort, DeleteCategoryInteractor>();
            services.AddTransient
                <IReadAllCategoryInputPort, ReadAllCategoryInteractor>();
            services.AddTransient
                <IReadCategoryInputPort, ReadCategoryInteractor>();
            services.AddTransient
                <IUpdateCategoryInputPort, UpdateCategoryInteractor>();

            return services;
        }
    }
}

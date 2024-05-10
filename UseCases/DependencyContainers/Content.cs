using Microsoft.Extensions.DependencyInjection;
using UseCases.ContentUC;
using UseCasesPort.ContentPorts.Inputs;

namespace UseCases.DependencyContainers
{
    public static class Content
    {
        public static IServiceCollection AddContentServices
            (this IServiceCollection services)
        {
            services.AddTransient
                <ICreateContentInputPort, CreateContentInteractor>();
            services.AddTransient
                <IDeleteContentInputPort, DeleteContentInteractor>();
            services.AddTransient
                <IReadAllContentInputPort, ReadAllContentInteractor>();
            services.AddTransient
                <IReadContentInputPort, ReadContentInteractor>();
            services.AddTransient
                <IUpdateContentInputPort, UpdateContentInteractor>();
            services.AddTransient
                <IViewContentInputPort, ViewContentInteractor>();

            return services;
        }
    }
}

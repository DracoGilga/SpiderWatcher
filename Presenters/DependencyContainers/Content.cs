using Microsoft.Extensions.DependencyInjection;
using Presenters.Content;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.DependencyContainers
{
    public static class Content
    {
        public static IServiceCollection AddContentPresenters(
                       this IServiceCollection services)
        {
            services.AddScoped<ICreateContentOutputPort,
                CreateContentPresenter>();
            services.AddScoped<IDeleteContentOutputPort,
                DeleteContentPresenter>();
            services.AddScoped<IReadAllContentOutputPort,
                ReadAllContentPresenter>();
            services.AddScoped<IReadContentOutputPort,
                ReadContentPresenter>();
            services.AddScoped<IUpdateContentOutputPort,
                UpdateContentPresenter>();
            services.AddScoped<IViewContentOutputPort,
                ViewContentPresenter>();

            return services;
        }
    }
}

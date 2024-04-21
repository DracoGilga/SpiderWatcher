using Microsoft.Extensions.DependencyInjection;
using UseCases.HystoryPlaybackUC;
using UseCasesPort.HistoryPlaybackPorts.Inputs;

namespace UseCases.DependencyContainers
{
    public static class HistoryPlayback
    {
        public static IServiceCollection AddHistoryPlaybackServices(this IServiceCollection services)
        {
            services.AddTransient
                <ICreateHistoryPlaybackInputPort, CreateHistoryPlaybackInteractor>();
            services.AddTransient
                <IDeleteHistoryPlaybackInputPort, DeletehistoryPlayblackInteractor>();
            services.AddTransient
                <IReadAllHistoryPlaybackInputPort, ReadAllHistoryPlaybackInteractor>();
            services.AddTransient
                <IReadHistoryPlaybackInputPort, ReadHistoryPlaybackInteractor>();
            services.AddTransient
                <IUpdateHistoryPlaybackInputPort, UpdateHistoryPlaybackInteractor>();

            return services;
        }
    }
}

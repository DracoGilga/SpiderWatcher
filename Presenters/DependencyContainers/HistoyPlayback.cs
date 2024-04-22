using Microsoft.Extensions.DependencyInjection;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.DependencyContainers
{
    public static class HistoyPlayback
    {
        public static IServiceCollection AddHistoryPlaybackPresenters(
                       this IServiceCollection services)
        {
            services.AddScoped<ICreateHistoryPlaybackOutputPort,
                CreateHistoryPlaybackPresenter>();
            services.AddScoped<IDeleteHistoryPlaybackOutputPort,
                DeleteHistoryPlaybackPresenter>();
            services.AddScoped<IReadAllHistoryPlaybackOutputPort,
                ReadAllHistoryPlaybackPresenter>();
            services.AddScoped<IReadHistoryPlaybackOutputPort,
                ReadHistoryPlaybackPresenter>();
            services.AddScoped<IUpdateHistoryPlaybackOutputPort,
                UpdadeHistoryPlaybackPresenter>();

            return services;
        }
    }
}

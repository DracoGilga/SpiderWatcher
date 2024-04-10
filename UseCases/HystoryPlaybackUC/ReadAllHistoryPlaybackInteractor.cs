using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace UseCases.HystoryPlaybackUC
{
    public class ReadAllHistoryPlaybackInteractor : IReadAllHistoryPlaybackInputPort
    {
        readonly IHistoryPlaybackRepository repository;
        readonly IReadAllHistoryPlaybackOutputPort outputPort;

        public ReadAllHistoryPlaybackInteractor(IHistoryPlaybackRepository repository, IReadAllHistoryPlaybackOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public Task Handle()
        {
            var HistoryPlaybacks = repository.ReadAllHistoryPlaybacks().Select(p =>
                new HistoryPlaybacksDTO
                {
                    IdHistory = p.HistoryPlaybackId,
                    IdUser = p.UserId,
                    IdContent = p.ContentId,
                    PlaybackTime = p.PlaybackTime,
                    PlaybackDate = p.PlaybackDate
                });
            outputPort.Handle(HistoryPlaybacks);
            return Task.CompletedTask;
        }
    }
}

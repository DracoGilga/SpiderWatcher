using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace UseCases.HystoryPlaybackUC
{
    public class ReadHistoryPlaybackInteractor : IReadHistoryPlaybackInputPort
    {
        readonly IHistoryPlaybackRepository repository;
        readonly IReadHistoryPlaybackOutputPort outputPort;

        public ReadHistoryPlaybackInteractor(IHistoryPlaybackRepository repository, IReadHistoryPlaybackOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public async Task Handle(int IdHistoryPlayback)
        {
            HistoryPlayback NewHistoryPlayback = new()
            {
                HistoryPlaybackId = IdHistoryPlayback
            };
            HistoryPlayback HistoryPlayback = repository.ReadHistoryPlayback(NewHistoryPlayback.HistoryPlaybackId);
            await outputPort.Handle(
                new ReadHistoryPlaybackDTO
                {
                    IdHistory = HistoryPlayback.HistoryPlaybackId,
                    IdUser = HistoryPlayback.UserId,
                    IdContent = HistoryPlayback.ContentId,
                    PlaybackTime = HistoryPlayback.PlaybackTime,
                    PlaybackDate = HistoryPlayback.PlaybackDate
                }
            );
        }
    }
}

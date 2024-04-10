using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class DeleteHistoryPlaybackPresenter : IDeleteHistoryPlaybackOutputPort, IPresenter<DeleteHistoryPlaybackDTO>
    {
        public DeleteHistoryPlaybackDTO Content { get; private set;}

        public Task Handle(DeleteHistoryPlaybackDTO historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

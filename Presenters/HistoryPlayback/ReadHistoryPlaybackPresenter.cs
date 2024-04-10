using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class ReadHistoryPlaybackPresenter :
        IReadHistoryPlaybackOutputPort, 
        IPresenter<ReadHistoryPlaybackDTO>
    {
        public ReadHistoryPlaybackDTO Content { get; private set; }

        public Task Handle(ReadHistoryPlaybackDTO historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

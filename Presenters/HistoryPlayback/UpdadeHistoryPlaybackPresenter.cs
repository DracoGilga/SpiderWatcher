using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class UpdadeHistoryPlaybackPresenter : 
        IUpdateHistoryPlaybackOutputPort,
        IPresenter<HistoryPlaybacksDTO>
    {
        public HistoryPlaybacksDTO Content { get; private set; }

        public Task Handle(HistoryPlaybacksDTO historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

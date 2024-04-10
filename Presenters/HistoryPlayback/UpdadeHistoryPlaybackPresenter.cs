using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class UpdadeHistoryPlaybackPresenter : 
        IUpdateHistoryPlaybackOutputPort,
        IPresenter<UpdateHistoryPlaybackDTO>
    {
        public UpdateHistoryPlaybackDTO Content { get; private set; }

        public Task Handle(UpdateHistoryPlaybackDTO historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

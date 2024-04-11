using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class CreateHistoryPlaybackPresenter : 
        ICreateHistoryPlaybackOutputPort, IPresenter<CreateHistoryPlaybackDTO>
    {
        public CreateHistoryPlaybackDTO Content { get; private set; }

        public Task Handle(CreateHistoryPlaybackDTO historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

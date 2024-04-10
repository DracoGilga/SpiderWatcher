using DTOs.HistoryPlaybackDTO;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Presenters.HistoryPlayback
{
    public class ReadAllHistoryPlaybackPresenter :
        IReadAllHistoryPlaybackOutputPort,
        IPresenter<IEnumerable<HistoryPlaybacksDTO>>
    {
        public IEnumerable<HistoryPlaybacksDTO> Content { get; private set; }

        public Task Handle(IEnumerable<HistoryPlaybacksDTO> historyPlayback)
        {
            Content = historyPlayback;
            return Task.CompletedTask;
        }
    }
}

using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Inputs
{
    public interface IUpdateHistoryPlaybackInputPort
    {
        Task Handle(UpdateHistoryPlaybackDTO historyPlayback);
    }
}

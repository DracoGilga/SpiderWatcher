using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Outputs
{
    public interface IReadHistoryPlaybackOutputPort
    {
        Task Handle(HistoryPlaybacksDTO historyPlayback);
    }
}

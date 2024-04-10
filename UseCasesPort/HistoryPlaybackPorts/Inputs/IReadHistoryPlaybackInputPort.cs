using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Inputs
{
    public interface IReadHistoryPlaybackInputPort
    {
        Task Handle(int IdHistoryPlayback);
    }
}

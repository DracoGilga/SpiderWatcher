using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Inputs
{
    public interface IDeleteHistoryPlaybackInputPort
    {
        Task Handle(int IdHistoryPlayback);
    }
}

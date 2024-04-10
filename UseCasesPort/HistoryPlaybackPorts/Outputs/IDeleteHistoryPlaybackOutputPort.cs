using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Outputs
{
    public interface IDeleteHistoryPlaybackOutputPort
    {
        Task Handle(HistoryPlaybacksDTO historyPlayback);
    }
}

using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Outputs
{
    public interface ICreateHistoryPlaybackOutputPort
    {
        Task Handle(HistoryPlaybacksDTO historyPlayback);
    }
}

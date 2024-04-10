using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Outputs
{
    public interface IReadAllHistoryPlaybackOutputPort
    {
        Task Handle(IEnumerable<HistoryPlaybacksDTO> historyPlayback);
    }
}

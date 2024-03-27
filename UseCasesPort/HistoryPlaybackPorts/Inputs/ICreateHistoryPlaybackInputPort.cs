using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.HistoryPlaybackPorts.Inputs
{
    public interface ICreateHistoryPlaybackInputPort
    {
        Task Handle(CreateHistoryPlaybackDTO historyPlayback);
    }
}

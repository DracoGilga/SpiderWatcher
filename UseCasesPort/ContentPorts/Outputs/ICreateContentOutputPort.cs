using DTOs.ContentDTO;
using DTOs.HistoryPlaybackDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface ICreateContentOutputPort
    {
        Task Handle(CreateContentDTO content);
    }
}

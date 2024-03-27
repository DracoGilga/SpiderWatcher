using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface IUpdateContentOutputPort
    {
        Task Handle(UpdateContentDTO content);
    }
}

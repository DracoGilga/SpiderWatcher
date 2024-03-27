using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IUpdateContentInputPort
    {
        Task Handle(UpdateContentDTO content);
    }
}

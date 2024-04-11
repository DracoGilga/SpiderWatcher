using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IViewContentInputPort
    {
        Task Handle(int IdContent);
    }
}

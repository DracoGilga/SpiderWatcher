using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface ICreateContentInputPort
    {
        Task Handle(CreateContentDTO content);
    }
}

using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IDeleteContentInputPort
    {
        Task Handle(DeleteContentDTO content);
    }
}

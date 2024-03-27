using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface IDeleteContentOutputPort
    {
        Task Handle(DeleteContentDTO content);
    }
}

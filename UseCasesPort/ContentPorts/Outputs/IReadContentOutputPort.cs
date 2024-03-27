using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface IReadContentOutputPort
    {
        Task Handle(ReadContentDTO content);
    }
}

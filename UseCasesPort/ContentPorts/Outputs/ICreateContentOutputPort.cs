using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface ICreateContentOutputPort
    {
        Task Handle(ContentsDTO content);
    }
}

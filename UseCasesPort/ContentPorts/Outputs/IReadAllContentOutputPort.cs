using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface IReadAllContentOutputPort
    {
        Task Handle(IEnumerable<ContentsDTO> content);
    }
}

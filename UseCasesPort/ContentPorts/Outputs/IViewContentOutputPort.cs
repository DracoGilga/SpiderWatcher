using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Outputs
{
    public interface IViewContentOutputPort
    {
        Task Handle(ViewContentDTO content);
    }
}

using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IReadContentInputPort
    {
        Task Handle(int IdCsontent);
    }
}

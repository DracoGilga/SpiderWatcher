using DTOs.ContentDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IDeleteContentInputPort
    {
        Task Handle(int id);
    }
}

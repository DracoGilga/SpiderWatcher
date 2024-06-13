using DTOs.UserDTO;

namespace UseCasesPort.ContentPorts.Inputs
{
    public interface IReadAllContentInputPort
    {
        Task Handle(CreateUserSuccessDTO user);
    }
}

using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IReadUserInputPort
    {
        Task Handle(ReadUserDTO user);
    }
}

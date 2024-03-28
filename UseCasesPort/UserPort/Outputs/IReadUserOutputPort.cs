using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IReadUserOutputPort
    {
        Task Handle(ReadUserDTO user);
    }
}

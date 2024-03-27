using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IUpdatePasswordUserOutputPort
    {
        Task Handle(UpdatePasswordUserDTO user);
    }
}

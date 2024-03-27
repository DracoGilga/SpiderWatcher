using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IUpdateUserOutputPort
    {
        Task Handle(UpdateUserDTO user);
    }
}

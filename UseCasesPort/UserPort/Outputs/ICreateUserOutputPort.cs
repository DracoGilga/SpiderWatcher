using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface ICreateUserOutputPort
    {
        Task Handle(CreateUserDTO user);
    }
}

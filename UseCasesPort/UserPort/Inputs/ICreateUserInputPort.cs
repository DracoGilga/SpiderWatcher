using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface ICreateUserInputPort
    {
        Task Handle(CreateUserDTO user);
    }
}

using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface ILoginUserInputPort
    {
        Task Handle(LoginUserDTO user);
    }
}

using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IUpdatePasswordUserInputPort
    {
        Task Handle(UpdatePasswordUserDTO user);
    }
}

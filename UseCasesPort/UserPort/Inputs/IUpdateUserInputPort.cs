using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IUpdateUserInputPort
    {
        Task Handle(UpdateUserDTO user);
    }
}

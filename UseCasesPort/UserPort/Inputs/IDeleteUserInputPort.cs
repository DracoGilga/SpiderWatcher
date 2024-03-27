using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IDeleteUserInputPort
    {
        Task Handle(DeleteUserDTO user);
    }
}

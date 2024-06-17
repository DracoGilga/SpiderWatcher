using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IRecoverPasswordInputPort
    {
        Task Handle(RecoverPasswordDTO user);
    }
}

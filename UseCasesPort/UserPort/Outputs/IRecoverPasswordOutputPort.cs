using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IRecoverPasswordOutputPort
    {
        Task Handle(RecoverPasswordDTO user);
    }
}

using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Inputs
{
    public interface IUpgradeUserInputPort
    { 
        Task Handle(UpgradeUserDTO user);
    }
}

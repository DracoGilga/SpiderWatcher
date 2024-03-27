using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IUpgradeUserOutputPort
    {
        Task Handle(UpgradeUserDTO user);
    }
}

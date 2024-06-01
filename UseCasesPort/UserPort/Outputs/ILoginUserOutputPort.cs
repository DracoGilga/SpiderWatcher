using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface ILoginUserOutputPort
    {
        Task Handle(ResultLoginUserDTO user);
    }
}

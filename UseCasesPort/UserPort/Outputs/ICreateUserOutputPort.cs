using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface ICreateUserOutputPort
    {
        Task Handle(CreateUserSuccessDTO user);
    }
}

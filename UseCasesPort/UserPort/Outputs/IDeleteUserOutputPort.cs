using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IDeleteUserOutputPort
    {
        Task Handle(UsersDTO User);
    }
}

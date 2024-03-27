using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IDeleteUserOutputPort
    {
        Task Handle(DeleteUserDTO idUser);
    }
}

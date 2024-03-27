using DTOs.UserDTO;

namespace UseCasesPort.UserPort.Outputs
{
    public interface IReadAllUsersOutputPort
    {
        Task Handle(IEnumerable<UsersDTO> users);
    }
}

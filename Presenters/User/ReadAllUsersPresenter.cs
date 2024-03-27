using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class ReadAllUsersPresenter :
        IReadAllUsersOutputPort, IPresenter<IEnumerable<UsersDTO>>
    {
        public IEnumerable<UsersDTO> Content { get; private set; }

        public Task Handle(IEnumerable<UsersDTO> users)
        {
            Content = users;
            return Task.CompletedTask;
        }
    }
}

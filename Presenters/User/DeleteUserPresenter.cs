using UseCasesPort.UserPort.Outputs;
using DTOs.UserDTO;

namespace Presenters.User
{
    public class DeleteUserPresenter :
        IDeleteUserOutputPort, IPresenter<UsersDTO>
    {
        public UsersDTO Content { get; private set; }

        public Task Handle(UsersDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

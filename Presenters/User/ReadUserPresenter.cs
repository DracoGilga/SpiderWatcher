using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class ReadUserPresenter :
        IReadUserOutputPort, IPresenter<UsersDTO>
    {
        public UsersDTO Content { get; private set; }

        public Task Handle(UsersDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

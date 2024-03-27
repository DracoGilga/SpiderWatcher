using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class LoginUserPresenter :
        ILoginUserOutputPort, IPresenter<LoginUserDTO>
    {
        public LoginUserDTO Content { get; private set; }

        public Task Handle(LoginUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

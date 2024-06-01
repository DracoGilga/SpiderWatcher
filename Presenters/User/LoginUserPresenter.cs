using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class LoginUserPresenter :
        ILoginUserOutputPort, IPresenter<ResultLoginUserDTO>
    {
        public ResultLoginUserDTO Content { get; private set; }

        public Task Handle(ResultLoginUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

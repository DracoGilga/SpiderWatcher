using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class ReadUserPresenter :
        IReadUserOutputPort, IPresenter<ReadUserDTO>
    {
        public ReadUserDTO Content { get; private set; }

        public Task Handle(ReadUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

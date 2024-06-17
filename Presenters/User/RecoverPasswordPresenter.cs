using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class RecoverPasswordPresenter : IRecoverPasswordOutputPort,
        IPresenter<RecoverPasswordDTO>
    {
        public RecoverPasswordDTO Content { get; private set; }

        public Task Handle(RecoverPasswordDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

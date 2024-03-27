using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class UpdateUserPresenter :
        IUpdateUserOutputPort, IPresenter<UpdateUserDTO>
    {
        public UpdateUserDTO Content { get; private set; }

        public Task Handle(UpdateUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class UpdatePasswordUserPresenter :
        IUpdatePasswordUserOutputPort, IPresenter<UpdatePasswordUserDTO>
    {
        public UpdatePasswordUserDTO Content { get; private set; }

        public Task Handle(UpdatePasswordUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

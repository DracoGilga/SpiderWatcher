using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class DeleteUserPresenter :
        IDeleteUserOutputPort, IPresenter<DeleteUserDTO>
    {
        public DeleteUserDTO Content { get; private set; }

        public Task Handle(DeleteUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

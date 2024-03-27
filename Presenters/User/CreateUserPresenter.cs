using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class CreateUserPresenter :
        ICreateUserOutputPort, IPresenter<CreateUserDTO>
    {
        public CreateUserDTO Content { get; private set; }

        public Task Handle(CreateUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

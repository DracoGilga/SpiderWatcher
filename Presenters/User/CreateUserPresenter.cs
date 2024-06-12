using DTOs.UserDTO;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class CreateUserPresenter :
        ICreateUserOutputPort, IPresenter<CreateUserSuccessDTO>
    {
        public CreateUserSuccessDTO Content { get; private set; }

        public Task Handle(CreateUserSuccessDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

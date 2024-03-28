using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class LoginUserInteractor : ILoginUserInputPort
    {
        readonly IUserRepository Repository;
        readonly ILoginUserOutputPort OutputPort;

        public LoginUserInteractor(IUserRepository repository,
            ILoginUserOutputPort outputPort) =>
            (Repository, OutputPort) = 
            (repository, outputPort);

        public async Task Handle(LoginUserDTO user)
        {
            User NewUser = new()
            {
                UserName = user.UserName,
                Password = user.Password,
                Restore = user.Restore,
                Confirmation = user.Confirmation
            };

            var result = Repository.LoginUser(NewUser);
            if (result != null)
            {
                await OutputPort.Handle(
                new LoginUserDTO
                {
                    UserName = result.UserName,
                    Password = result.Password,
                    Restore = result.Restore,
                    Confirmation = result.Confirmation
                });
            }
        }
    }
}

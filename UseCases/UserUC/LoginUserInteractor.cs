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
                Password = user.Password
            };

            var result = Repository.LoginUser(NewUser);
            if (result != null)
            {
                await OutputPort.Handle(
                new ResultLoginUserDTO
                {
                    Restore = result.Restore,
                    Confirmation = result.Confirmation,
                    AccountType = result.AccountType
                });
            }
        }
    }
}

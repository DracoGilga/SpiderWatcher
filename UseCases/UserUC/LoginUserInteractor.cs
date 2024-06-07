using DTOs.UserDTO;
using Entities.Interface;
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
            var storedUser = Repository.LoginUser(user.UserName);

            if (storedUser != null && BCrypt.Net.BCrypt.Verify(user.Password, storedUser.Password))
            {
                await OutputPort.Handle(
                new ResultLoginUserDTO
                {
                    Restore = storedUser.Restore,
                    Confirmation = storedUser.Confirmation,
                    AccountType = storedUser.AccountType
                });
            }
            else
            {
                await OutputPort.Handle(null);
            }
        }
    }
}

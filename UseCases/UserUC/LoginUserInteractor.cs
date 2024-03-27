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
        readonly IUnitOfWork UnitOfWork;
        readonly ILoginUserOutputPort OutputPort;

        public LoginUserInteractor(IUserRepository repository, 
            IUnitOfWork unitOfWork, ILoginUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(LoginUserDTO user)
        {
            User NewUser = new()
            {
                UserName = user.UserName,
                Password = user.Password,
                Restore = user.Restore,
                Confirmation = user.Confirmation
            };

            Repository.LoginUser(NewUser);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new LoginUserDTO
                {
                    UserName = NewUser.UserName,
                    Password = NewUser.Password,
                    Restore = NewUser.Restore,
                    Confirmation = NewUser.Confirmation
                });
        }
    }
}

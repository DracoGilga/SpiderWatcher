using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class UpgradeUserInteractor : IUpgradeUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpgradeUserOutputPort OutputPort;
        
        public UpgradeUserInteractor(IUserRepository repository, 
                       IUnitOfWork unitOfWork, IUpgradeUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpgradeUserDTO user)
        {
            User NewUser = new()
            {
                UserId = user.IdUser,
                UserName = user.UserName,
                AccountType = true
            };

            Repository.UpgradeUser(NewUser);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new UpgradeUserDTO
                {
                    IdUser = NewUser.UserId,
                    UserName = NewUser.UserName,
                    AccountType = NewUser.AccountType
                });
        }
    }
}

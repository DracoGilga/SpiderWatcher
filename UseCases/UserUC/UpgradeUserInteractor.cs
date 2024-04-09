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
            User existingUser = Repository.ReadUser(user.IdUser);
            if (existingUser != null)
            {
                if (user.AccountType)
                {
                    existingUser.AccountType = user.AccountType;
                    bool success = Repository.UpdateUser(existingUser);
                    if (success)
                    {
                        await UnitOfWork.SaveChanges();
                        await OutputPort.Handle(user);
                    }
                }
            }
        }
    }
}

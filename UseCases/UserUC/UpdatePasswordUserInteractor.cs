using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class UpdatePasswordUserInteractor : IUpdatePasswordUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdatePasswordUserOutputPort OutputPort;

        public UpdatePasswordUserInteractor(IUserRepository repository, 
                       IUnitOfWork unitOfWork, IUpdatePasswordUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpdatePasswordUserDTO user)
        {
            User existingUser = Repository.ReadUser(user.IdUser);
            if (existingUser != null)
            {
                if (!existingUser.Restore)
                {
                    existingUser.Restore = true;
                    existingUser.Password = user.Password;
                }

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

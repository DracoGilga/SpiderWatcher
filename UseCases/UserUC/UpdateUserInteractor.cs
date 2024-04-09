using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    internal class UpdateUserInteractor : IUpdateUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateUserOutputPort OutputPort;

        public UpdateUserInteractor(IUserRepository repository, 
            IUnitOfWork unitOfWork, IUpdateUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpdateUserDTO user)
        {
            User existingUser = Repository.ReadUser(user.IdUser);
            if (existingUser != null)
            {
                if (!string.IsNullOrEmpty(user.Email))
                    existingUser.Email = user.Email;
                if (!string.IsNullOrEmpty(user.Name))
                    existingUser.Name = user.Name;
                if (!string.IsNullOrEmpty(user.LastName))
                    existingUser.LastName = user.LastName;

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

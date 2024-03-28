using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class DeleteUserInteractor : IDeleteUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteUserOutputPort OutputPort;

        public DeleteUserInteractor(IUserRepository repository, 
            IUnitOfWork unitOfWork, IDeleteUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(int IdUser)
        {
            User NewUser = new()
            {
                UserId = IdUser
            };

            var result =Repository.DeleteUser(NewUser.UserId);
            await UnitOfWork.SaveChanges();
            if (result != null)
            {
                await OutputPort.Handle(
                    new UsersDTO
                    {
                        IdUser = result.UserId,
                        Email = result.Email,
                        Name = result.Name,
                        LastName = result.LastName,
                        AccountType = result.AccountType,
                        DateBirth = result.DateBirth,
                        UserName = result.UserName,
                        Password = result.Password,
                        Restore = result.Restore,
                        Confirmation = result.Confirmation
                    }
                );
            }
        }
    }
}

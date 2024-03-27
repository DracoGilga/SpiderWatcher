using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class CreateUserInteractor : ICreateUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateUserOutputPort OutputPort;

        public CreateUserInteractor(IUserRepository repository, 
            IUnitOfWork unitOfWork, ICreateUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(CreateUserDTO user)
        {
            User NewUser = new()
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                AccountType = false,
                DateBirth = user.DateBirth,
                UserName = user.UserName,
                Password = user.Password,
                Restore = false,
                Confirmation = false
            };

            Repository.CreateUser(NewUser);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new CreateUserDTO
                {
                    Email = NewUser.Email,
                    Name = NewUser.Name,
                    LastName = NewUser.LastName,
                    AccountType = NewUser.AccountType,
                    DateBirth = NewUser.DateBirth,
                    UserName = NewUser.UserName,
                    Password = NewUser.Password,
                    Confirmation = NewUser.Confirmation
                });
        }
    }
}

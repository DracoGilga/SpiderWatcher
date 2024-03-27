using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class ReadUserInteractor : IReadUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IReadUserOutputPort OutputPort;

        public ReadUserInteractor(IUserRepository repository, 
            IUnitOfWork unitOfWork, IReadUserOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(ReadUserDTO user)
        {
            User NewUser = new()
            {
                UserId = user.IdUser,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            };

            User User = Repository.ReadUser(NewUser.UserId);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new UsersDTO
                {
                    IdUser = User.UserId,
                    Email = User.Email,
                    UserName = User.UserName,
                    Password = User.Password
                });
        }
    }
}

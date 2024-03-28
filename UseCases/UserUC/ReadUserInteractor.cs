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

        readonly IReadUserOutputPort OutputPort;

        public ReadUserInteractor(IUserRepository repository,
            IReadUserOutputPort outputPort) =>
            (Repository, OutputPort) = 
            (repository, outputPort);

        public async Task Handle(int IdUser)
        {
            User NewUser = new()
            {
                UserId = IdUser
            };

            User User = Repository.ReadUser(NewUser.UserId);
            await OutputPort.Handle(
                new ReadUserDTO
                {
                    IdUser = User.UserId,
                    Email = User.Email,
                    UserName = User.UserName,
                    Password = User.Password
                });
        }
    }
}

using DTOs.UserDTO;
using Entities.Interface;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class ReadAllUsersInteractor : IReadAllUsersInputPort
    {
        readonly IUserRepository Repository;
        readonly IReadAllUsersOutputPort OutputPort;

        public ReadAllUsersInteractor(IUserRepository repository, IReadAllUsersOutputPort outputPort) =>
            (Repository, OutputPort) = (repository, outputPort);

        public Task Handle()
        {
            var Users = Repository.ReadAllUsers().Select(p => new UsersDTO
            {
                IdUser = p.UserId,
                Email = p.Email,
                Name = p.Name,
                LastName = p.LastName,
                AccountType = p.AccountType,
                DateBirth = p.DateBirth,
                UserName = p.UserName,
                Password = p.Password,
                Restore = p.Restore,
                Confirmation = p.Confirmation
            });

            OutputPort.Handle(Users);
            return Task.CompletedTask;
        }
    }
}

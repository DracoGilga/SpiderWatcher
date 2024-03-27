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
            User NewUser = new()
            {
                UserId = user.IdUser,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName
            };

            Repository.UpdateUser(NewUser);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new UpdateUserDTO
                {
                    IdUser = NewUser.UserId,
                    Email = NewUser.Email,
                    Name = NewUser.Name,
                    LastName = NewUser.LastName
                });
        }
    }
}

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

        public async Task Handle(DeleteUserDTO user)
        {
            User NewUser = new()
            {
                UserId = user.IdUser
            };

            Repository.DeleteUser(NewUser.UserId);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new DeleteUserDTO
                {
                    IdUser = NewUser.UserId,
                });
        }
    }
}

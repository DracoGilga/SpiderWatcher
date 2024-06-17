using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class RecoverPasswordInteractor : IRecoverPasswordInputPort
    {
        readonly IValidationRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IRecoverPasswordOutputPort OutputPort;
        readonly ISentEmail SentEmail;

        public RecoverPasswordInteractor(IValidationRepository repository,
            IUnitOfWork unitOfWork, IRecoverPasswordOutputPort outputPort,
            ISentEmail sentEmail) =>
            (Repository, UnitOfWork, OutputPort, SentEmail) =
            (repository, unitOfWork, outputPort, sentEmail);

        public async Task Handle(RecoverPasswordDTO user)
        {
            string ValidationMessage = Repository.RecoverPasswordValidation(user.Email);

            User NewUserEmail = new()
            {
                Email = user.Email,
                Password = ValidationMessage
            };

            bool success;
            do
            {
                success = SentEmail.CreateUserEmail(NewUserEmail);
            } while (!success);

            if (success)
            {
                OutputPort.Handle(user);
            }
            else
            {
                throw new Exception("Failed to send recovery email. Please try again later.");
            }
        }

    }
}

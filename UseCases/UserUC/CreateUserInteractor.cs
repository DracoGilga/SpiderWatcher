using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using System.Text;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class CreateUserInteractor : ICreateUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IValidationRepository ValidationRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateUserOutputPort OutputPort;
        readonly ISentEmail SentEmail;

        public CreateUserInteractor(IUserRepository repository, IValidationRepository validationRepository,
            IUnitOfWork unitOfWork, ICreateUserOutputPort outputPort, ISentEmail sentEmail) =>
            (Repository, ValidationRepository, UnitOfWork, OutputPort, SentEmail) = 
            (repository, validationRepository, unitOfWork, outputPort, sentEmail);

        public async Task Handle(CreateUserDTO user)
        {
            string ValidationMessage = GenerateRandomCode(20);
            DateTime initDateTime = DateTime.Now;

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

            var NewValidation = new Validation
            {
                UserId = NewUser.UserId,
                ValidationMessage = ValidationMessage,
                InitDateTime = initDateTime
            };

            ValidationRepository.CreateValidation(NewValidation);

            User NewUserEmail = new()
            {
                Email = NewUser.Email,
                Password = ValidationMessage
            };

            bool success;
            do
            {
                success = SentEmail.CreateUserEmail(NewUserEmail);
            } while (!success);

            if (success) 
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
                    }
                );
        }

        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+";
            var random = new Random();
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }
}

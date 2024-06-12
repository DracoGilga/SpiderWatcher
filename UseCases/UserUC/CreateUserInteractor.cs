using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using System.Text;
using System.Text.RegularExpressions;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;
using DTOs;

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
            if (!IsValidEmail(user.Email))
                throw new ValidationException("The email address is not valid.");

            if (user.Name.Length > 25 || user.Name.Length <= 0)
                throw new ValidationException("The name must be more than 0 characters and less than 25 characters.");

            if (user.LastName.Length > 35 || user.LastName.Length <= 0)
                throw new ValidationException("The last name must be more than 0 characters and less than 35 characters.");

            if (user.UserName.Length > 20 || user.UserName.Length <= 0)
                throw new ValidationException("The username must be more than 0 characters and less than 20 characters.");

            if (user.Password.Length <= 8 || user.Password.Length >= 21)
                throw new ValidationException("The password must be more than 8 characters and less than 21 characters.");

            if (user.DateBirth.ToDateTime(TimeOnly.MinValue) >= DateTime.Now)
                throw new ValidationException("The date of birth must be in the past.");

            string ValidationMessage = GenerateRandomCode(20);
            DateTime initDateTime = DateTime.Now;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            User NewUser = new()
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                AccountType = false,
                DateBirth = user.DateBirth,
                UserName = user.UserName,
                Password = hashedPassword,
                Restore = false,
                Confirmation = false
            };

            int Response = Repository.CreateUser(NewUser);
            await UnitOfWork.SaveChanges();

            var NewValidation = new Validation
            {
                UserId = NewUser.UserId,
                ValidationMessage = ValidationMessage,
                InitDateTime = initDateTime
            };

            ValidationRepository.CreateValidation(NewValidation);
            await UnitOfWork.SaveChanges();

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
                    new CreateUserSuccessDTO
                    {
                        IdUser = Response
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

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
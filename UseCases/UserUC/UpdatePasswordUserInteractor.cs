using DTOs.UserDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UseCases.UserUC
{
    public class UpdatePasswordUserInteractor : IUpdatePasswordUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IValidationRepository ValidationRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdatePasswordUserOutputPort OutputPort;

        public UpdatePasswordUserInteractor(IUserRepository repository, IValidationRepository validationRepository, 
                       IUnitOfWork unitOfWork, IUpdatePasswordUserOutputPort outputPort) =>
            (Repository, ValidationRepository, UnitOfWork, OutputPort) = 
            (repository, validationRepository, unitOfWork, outputPort);

        public async Task Handle(UpdatePasswordUserDTO userDto)
        {
            try
            {
                int userId = Repository.ReadUserXEmail(userDto.Email);
                User user = Repository.ReadUser(userId);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                if (!string.IsNullOrEmpty(userDto.ValidationMessage))
                {
                    Validation validation = new()
                    {
                        UserId = userId,
                        ValidationMessage = userDto.ValidationMessage
                    };

                    if (!ValidationRepository.ReadValidation(validation))
                        throw new InvalidOperationException("Invalid validation code");
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                user.Restore = false;

                if (!Repository.UpdatePasswordUser(user))
                {
                    throw new InvalidOperationException("Failed to update user password");
                }

                await UnitOfWork.SaveChanges();

                await OutputPort.Handle(userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


    }
}

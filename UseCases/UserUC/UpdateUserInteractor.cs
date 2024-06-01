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
        readonly IValidationRepository ValidationRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateUserOutputPort OutputPort;

        public UpdateUserInteractor(IUserRepository repository, 
            IValidationRepository validationRepository, 
            IUnitOfWork unitOfWork, IUpdateUserOutputPort outputPort) =>
            (Repository, ValidationRepository, UnitOfWork, OutputPort) = 
            (repository, validationRepository, unitOfWork, outputPort);

        public async Task Handle(UpdateUserDTO user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentException("Invalid user data");

                if (!string.IsNullOrEmpty(user.ValidationMessage))
                {
                    Validation validation = new()
                    {
                        UserId = user.IdUser,
                        ValidationMessage = user.ValidationMessage
                    };

                    if (!ValidationRepository.ReadValidation(validation))
                        throw new InvalidOperationException("Invalid validation code");
                }

                User existingUser = Repository.ReadUser(user.IdUser);
                if (existingUser == null)
                    throw new KeyNotFoundException("User not found");

                if (!existingUser.Confirmation)
                {
                    existingUser.Confirmation = true;
                    
                    if (Repository.UpdateUser(existingUser))
                    {
                        await UnitOfWork.SaveChanges();
                        await OutputPort.Handle(user);
                    }
                    else
                        throw new InvalidOperationException("Failed to update user");
                }
                else
                    await OutputPort.Handle(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }

    }
}

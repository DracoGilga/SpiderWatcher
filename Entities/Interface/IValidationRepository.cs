using Entities.Poco;

namespace Entities.Interface
{
    public interface IValidationRepository
    {
        void CreateValidation(Validation validation);
        bool ReadValidation(Validation validation);

        string RecoverPasswordValidation(string Email);
    }
}

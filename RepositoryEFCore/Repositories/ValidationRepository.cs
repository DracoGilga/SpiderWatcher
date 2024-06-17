using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    internal class ValidationRepository : IValidationRepository
    {
        readonly SpiderWatcherContext Context;
        public ValidationRepository(SpiderWatcherContext context)
            => Context = context;

        public void CreateValidation(Validation validation) => Context.Add(validation);

        public bool ReadValidation(Validation validation)
        {
            var validationInDb = Context.Validations
                .FirstOrDefault(v => v.ValidationMessage == validation.ValidationMessage &&
                v.UserId == validation.UserId);

            if (validationInDb == null)
                throw new Exception("Validation not found.");

            if (validationInDb.Used)
                return false;
            else
            {
                validationInDb.Used = true;
                Context.SaveChanges();
                return true;
            }
        }

        public string RecoverPasswordValidation(string email)
        {
            var user = Context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return null;

            user.Restore = true;

            var random = new Random();
            var validationMessage = random.Next(10000, 99999).ToString();
            var validation = new Validation
            {
                UserId = user.UserId,
                ValidationMessage = validationMessage,
                InitDateTime = DateTime.Now,
                Used = false
            };

            Context.Validations.Add(validation);

            Context.SaveChanges();

            return validationMessage;
        }

    }
}

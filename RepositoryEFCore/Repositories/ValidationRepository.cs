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
    }
}

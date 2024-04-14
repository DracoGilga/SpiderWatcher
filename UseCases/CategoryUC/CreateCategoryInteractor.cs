using DTOs.CategoryDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace UseCases.CategoryUC
{
    public class CreateCategoryInteractor : ICreateCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateCategoryOutputPort OutputPort;

        public CreateCategoryInteractor(ICategoryRepository repository, 
            IUnitOfWork unitOfWork, ICreateCategoryOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(CreateCategoryDTO category)
        {
            Category NewCategory = new()
            {
                Genre = category.Genre,
                MiniumAge = category.MiniumAge
            };
            Repository.CreateCategory(NewCategory);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new CategoriesDTO
                {
                    IdCategory = NewCategory.CategoryId,                 
                    Genre = NewCategory.Genre,
                    MiniumAge = NewCategory.MiniumAge
                });
        }
    }
}

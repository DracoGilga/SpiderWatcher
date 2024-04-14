using DTOs.CategoryDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace UseCases.CategoryUC
{
    public class DeleteCategoryInteractor : IDeleteCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteCategoryOutputPort OutputPort;

        public DeleteCategoryInteractor(ICategoryRepository repository, 
            IUnitOfWork unitOfWork, IDeleteCategoryOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(int IdCategory)
        {
            Category NewCategory = new()
            {
                CategoryId = IdCategory
            };
            var result = Repository.DeleteCategory(NewCategory.CategoryId);
            await UnitOfWork.SaveChanges();
            if (result != null)
            {
                await OutputPort.Handle(
                    new CategoriesDTO
                    {
                        IdCategory = result.CategoryId,
                        Genre = result.Genre,
                        MiniumAge = result.MiniumAge
                    }
                );
            }
        }
    }
}

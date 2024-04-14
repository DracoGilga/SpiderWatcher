using DTOs.CategoryDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace UseCases.CategoryUC
{
    public class UpdateCategoryInteractor : IUpdateCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateCategoryOutputPort OutputPort;

        public UpdateCategoryInteractor(ICategoryRepository repository, 
            IUnitOfWork unitOfWork, IUpdateCategoryOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpdateCategoryDTO category)
        {
            Category existingCategory = Repository.ReadCategory(category.Id);
            if (existingCategory != null)
            {
                if (!string.IsNullOrEmpty(category.Genre))
                    existingCategory.Genre = category.Genre;
                
                if (!int.IsPositive(category.MiniumAge))
                    existingCategory.MiniumAge = category.MiniumAge;
                
                bool success = Repository.UpdateCategory(existingCategory);
                if (success)
                {
                    await UnitOfWork.SaveChanges();
                    await OutputPort.Handle(
                        new UpdateCategoryDTO
                        {
                            Id = existingCategory.CategoryId,
                            Genre = existingCategory.Genre,
                            MiniumAge = existingCategory.MiniumAge
                        }
                    );
                }

            }
        }
    }
}

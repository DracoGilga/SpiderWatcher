using DTOs.CategoryDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace UseCases.CategoryUC
{
    public class ReadCategoryInteractor : IReadCategoryInputPort
    {
        readonly ICategoryRepository repository;
        readonly IReadCategoryOutputPort outputPort;

        public ReadCategoryInteractor(ICategoryRepository repository, IReadCategoryOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public async Task Handle(int IdCategory)
        {
            Category NewCategory = new()
            {
                CategoryId = IdCategory
            };
            Category Category = repository.ReadCategory(NewCategory.CategoryId);
            await outputPort.Handle(
                new ReadCategoryDTO
                {
                    Genre = Category.Genre,
                    MiniumAge = Category.MiniumAge,
                });
        }
    }
}

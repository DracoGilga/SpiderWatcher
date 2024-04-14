using DTOs.CategoryDTO;
using Entities.Interface;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace UseCases.CategoryUC
{
    public class ReadAllCategoryInteractor : IReadAllCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IReadAllCategoryOutputPort OutputPort;

        public ReadAllCategoryInteractor(ICategoryRepository repository, IReadAllCategoryOutputPort outputPort) =>
            (Repository, OutputPort) = (repository, outputPort);

        public Task Handle()
        {
            var categories = Repository.ReadAllCategories().Select(c =>
                new ReadCategoryDTO
                {
                    Genre = c.Genre,
                    MiniumAge = c.MiniumAge
                }
            );
            OutputPort.Handle(categories);
            return Task.CompletedTask;
        }
    }
}

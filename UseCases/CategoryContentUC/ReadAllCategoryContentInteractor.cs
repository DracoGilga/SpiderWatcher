using DTOs.CategoryContentDTO;
using Entities.Interface;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace UseCases.CategoryContentUC
{
    public class ReadAllCategoryContentInteractor : IReadAllCategoryContentInputPort
    {
        readonly ICategoryContentRepository repository;
        readonly IReadAllCategoryContentOutputPort outputPort;

        public ReadAllCategoryContentInteractor(ICategoryContentRepository repository, IReadAllCategoryContentOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public Task Handle()
        {
            var CategoryContents = repository.ReadAllCategoryContents().Select(p =>
                new ReadCategoryContentDTO
                {
                    IdCategoryContent = p.CategoryContentId,
                    IdCategory = p.CategoryId,
                    IdContent = p.ContentId
                });
            outputPort.Handle(CategoryContents);
            return Task.CompletedTask;
        }
    }
}

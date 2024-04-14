using DTOs.CategoryContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace UseCases.CategoryContentUC
{
    public class ReadCategoryContentInteractor : IReadCategoryContentInputPort
    {
        readonly ICategoryContentRepository repository;
        readonly IReadCategoryContentOutputPort outputPort;

        public ReadCategoryContentInteractor(ICategoryContentRepository repository, IReadCategoryContentOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public async Task Handle(int IdCategoryContent)
        {
            CategoryContent NewCategoryContent = new()
            {
                CategoryContentId = IdCategoryContent
            };
            CategoryContent CategoryContent = repository.ReadCategoryContent(NewCategoryContent.CategoryContentId);
            await outputPort.Handle(
               new ReadCategoryContentDTO
                {
                    IdCategoryContent = CategoryContent.CategoryContentId,
                    IdCategory = CategoryContent.CategoryId,
                    IdContent = CategoryContent.ContentId
                }
            );
        }
    }
}

using DTOs.CategoryContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace UseCases.CategoryContentUC
{
    public class CreateCategoryContentInteractor : ICreateCategoryContentInputPort
    {
        readonly ICategoryContentRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateCategoryContentOutputPort OutputPort;

        public CreateCategoryContentInteractor(ICategoryContentRepository repository, 
            IUnitOfWork unitOfWork, ICreateCategoryContentOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(CreateCategoryContentDTO categoryContent)
        {
            CategoryContent NewCategoryContent = new()
            {
                CategoryId = categoryContent.IdCategory,
                ContentId = categoryContent.IdContent
            };

            Repository.CreateCategoryContent(NewCategoryContent);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new CategoryContentsDTO
                {
                    IdCategoryContent = NewCategoryContent.CategoryContentId,
                    IdCategory = NewCategoryContent.CategoryId,
                    IdContent = NewCategoryContent.ContentId
                });
        }
    }
}

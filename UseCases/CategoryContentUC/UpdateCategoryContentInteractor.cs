using DTOs.CategoryContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace UseCases.CategoryContentUC
{
    public class UpdateCategoryContentInteractor : IUpdateCategoryContentInputPort
    {
        readonly ICategoryContentRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateCategoryContentOutputPort OutputPort;

        public UpdateCategoryContentInteractor(ICategoryContentRepository repository, 
            IUnitOfWork unitOfWork, IUpdateCategoryContentOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpdateCategoryContentDTO categoryContent)
        {
            CategoryContent existingCategoryContent = Repository.ReadCategoryContent(categoryContent.IdCategoryContent);
            if (existingCategoryContent != null)
            {
                if (!int.IsPositive(categoryContent.IdCategory))
                    existingCategoryContent.CategoryId = categoryContent.IdCategory;
                
                if (!int.IsPositive(categoryContent.IdContent))
                    existingCategoryContent.ContentId = categoryContent.IdContent;
               
                bool success = Repository.UpdateCategoryContent(existingCategoryContent);
                if (success)
                {
                    await UnitOfWork.SaveChanges();
                    await OutputPort.Handle(
                        new UpdateCategoryContentDTO
                        {
                            IdCategoryContent = existingCategoryContent.CategoryContentId,
                            IdCategory = existingCategoryContent.CategoryId,
                            IdContent = existingCategoryContent.ContentId
                        }
                    );
                }
            }
        }
    }
}

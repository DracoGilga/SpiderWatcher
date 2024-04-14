using DTOs.CategoryContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace UseCases.CategoryContentUC
{
    public class DeleteCategoryContentInteractor : IDeleteCategoryContentInputPort
    {
        readonly ICategoryContentRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteCategoryContentOutputPort OutputPort;

        public DeleteCategoryContentInteractor(ICategoryContentRepository repository, 
            IUnitOfWork unitOfWork, IDeleteCategoryContentOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(int IdCategoryContent)
        {
            CategoryContent NewCategoryContent = new()
            {
                CategoryContentId = IdCategoryContent
            };
            var result = Repository.DeleteCategoryContent(NewCategoryContent.CategoryContentId);
            await UnitOfWork.SaveChanges();
            if (result != null)
            {
                await OutputPort.Handle(
                    new DeleteCategoryContentDTO
                    {
                        IdCategoryContent = result.CategoryContentId
                    }
                );
            }
        }
    }
}

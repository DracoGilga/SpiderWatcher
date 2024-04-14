using DTOs.CategoryContentDTO;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.CategoryContent
{
    public class DeleteCategoryContentPresenter :
        IDeleteCategoryContentOutputPort, IPresenter<DeleteCategoryContentDTO>
    {
        public DeleteCategoryContentDTO Content { get; private set;}

        public Task Handle(DeleteCategoryContentDTO categoryContent)
        {
            Content = categoryContent;
            return Task.CompletedTask;
        }
    }
}

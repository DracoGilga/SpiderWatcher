using DTOs.CategoryContentDTO;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.CategoryContent
{
    public class DeleteCategoryContentPresenter :
        IDeleteCategoryContentOutputPort, IPresenter<CategoryContentsDTO>
    {
        public CategoryContentsDTO Content { get; private set;}

        public Task Handle(CategoryContentsDTO categoryContent)
        {
            Content = categoryContent;
            return Task.CompletedTask;
        }
    }
}

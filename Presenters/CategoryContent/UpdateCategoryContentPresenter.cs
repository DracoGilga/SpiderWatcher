using DTOs.CategoryContentDTO;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.CategoryContent
{
    public class UpdateCategoryContentPresenter : 
        IUpdateCategoryContentOutputPort,
        IPresenter<UpdateCategoryContentDTO>
    {
        public UpdateCategoryContentDTO Content { get; private set; }

        public Task Handle(UpdateCategoryContentDTO categoryContent)
        {
            Content = categoryContent;
            return Task.CompletedTask;
        }
    }
}

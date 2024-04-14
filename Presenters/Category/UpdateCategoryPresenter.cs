using DTOs.CategoryDTO;
using UseCasesPort.CategoryPorts.Outputs;

namespace Presenters.Category
{
    public class UpdateCategoryPresenter : IUpdateCategoryOutputPort, IPresenter<UpdateCategoryDTO>
    {
        public UpdateCategoryDTO Content { get; private set; }

        public Task Handle(UpdateCategoryDTO category)
        {
            Content = category;
            return Task.CompletedTask;
        }
    }
}

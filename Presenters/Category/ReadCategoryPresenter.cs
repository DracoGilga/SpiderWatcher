using DTOs.CategoryDTO;
using UseCasesPort.CategoryPorts.Outputs;

namespace Presenters.Category
{
    public class ReadCategoryPresenter : IReadCategoryOutputPort,
        IPresenter<ReadCategoryDTO>
    {
        public ReadCategoryDTO Content { get; private set; }

        public Task Handle(ReadCategoryDTO category)
        {
            Content = category;
            return Task.CompletedTask;
        }
    }
}

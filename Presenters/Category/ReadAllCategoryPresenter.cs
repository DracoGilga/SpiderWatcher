using DTOs.CategoryDTO;
using UseCasesPort.CategoryPorts.Outputs;

namespace Presenters.Category
{
    public class ReadAllCategoryPresenter :
        IReadAllCategoryOutputPort,
        IPresenter<IEnumerable<ReadCategoryDTO>>
    {
        public IEnumerable<ReadCategoryDTO> Content { get; private set; }

        public Task Handle(IEnumerable<ReadCategoryDTO> category)
        {
            Content = category;
            return Task.CompletedTask;
        }
    }
}

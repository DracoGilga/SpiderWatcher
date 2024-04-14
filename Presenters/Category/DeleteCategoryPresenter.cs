using DTOs.CategoryDTO;
using UseCasesPort.CategoryPorts.Outputs;

namespace Presenters.Category
{
    public class DeleteCategoryPresenter : IDeleteCategoryOutputPort,
        IPresenter<CategoriesDTO>
    {
        public CategoriesDTO Content { get; private set;}

        public Task Handle(CategoriesDTO category)
        {
            Content = category;
            return Task.CompletedTask;
        }
    }
}

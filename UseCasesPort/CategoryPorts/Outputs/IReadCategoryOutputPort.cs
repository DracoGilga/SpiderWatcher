using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface IReadCategoryOutputPort
    {
        Task Handle(CategoriesDTO category);
    }
}

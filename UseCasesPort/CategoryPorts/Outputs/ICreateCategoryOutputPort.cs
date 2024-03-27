using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface ICreateCategoryOutputPort
    {
        Task Handle(CategoriesDTO category);
    }
}

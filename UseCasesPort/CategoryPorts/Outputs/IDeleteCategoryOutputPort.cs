using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface IDeleteCategoryOutputPort
    {
        Task Handle(DeleteCategoryDTO category);
    }
}

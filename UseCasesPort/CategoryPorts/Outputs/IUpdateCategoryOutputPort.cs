using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface IUpdateCategoryOutputPort
    {
        Task Handle(UpdateCategoryDTO category);
    }
}

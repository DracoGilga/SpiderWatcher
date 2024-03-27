using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Inputs
{
    public interface IUpdateCategoryInputPort
    {
        Task Handle(UpdateCategoryDTO category);
    }
}

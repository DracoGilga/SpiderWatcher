using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Inputs
{
    public interface ICreateCategoryInputPort
    {
        Task Handle(CreateCategoryDTO category);
    }
}

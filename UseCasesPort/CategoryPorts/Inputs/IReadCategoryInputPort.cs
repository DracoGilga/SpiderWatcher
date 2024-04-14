using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Inputs
{
    public interface IReadCategoryInputPort
    {
        Task Handle(int IdCategory);
    }
}

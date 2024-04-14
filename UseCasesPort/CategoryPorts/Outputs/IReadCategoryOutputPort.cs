using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface IReadCategoryOutputPort
    {
        Task Handle(ReadCategoryDTO category);
    }
}

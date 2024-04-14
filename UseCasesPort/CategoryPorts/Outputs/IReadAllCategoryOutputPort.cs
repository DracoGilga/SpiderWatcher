using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Outputs
{
    public interface IReadAllCategoryOutputPort
    {
        Task Handle(IEnumerable<ReadCategoryDTO> category);
    }
}

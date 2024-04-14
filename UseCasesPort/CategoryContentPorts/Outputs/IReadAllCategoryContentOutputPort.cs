using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Outputs
{
    public interface IReadAllCategoryContentOutputPort
    {
        Task Handle(IEnumerable<ReadCategoryContentDTO> categoryContent);
    }
}

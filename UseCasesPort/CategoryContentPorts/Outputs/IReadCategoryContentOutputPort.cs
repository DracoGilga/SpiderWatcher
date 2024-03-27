using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Outputs
{
    public interface IReadCategoryContentOutputPort
    {
        Task Handle(ReadCategoryContentDTO categoryContent);
    }
}

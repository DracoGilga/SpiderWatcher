using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Inputs
{
    public interface IReadCategoryContentInputPort
    {
        Task Handle(ReadCategoryContentDTO categoryContent);
    }
}

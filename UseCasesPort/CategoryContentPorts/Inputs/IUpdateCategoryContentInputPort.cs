using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Inputs
{
    public interface IUpdateCategoryContentInputPort
    {
        Task Handle(UpdateCategoryContentDTO categoryContent);
    }
}

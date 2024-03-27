using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Outputs
{
    public interface IUpdateCategoryContentOutputPort
    {
        Task Handle(UpdateCategoryContentDTO categoryContent);
    }
}

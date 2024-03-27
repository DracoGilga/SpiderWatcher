using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Outputs
{
    public interface ICreateCategoryContentOutputPort
    {
        Task Handle(CategoryContentsDTO categoryContent);
    }
}

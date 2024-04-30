using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Outputs
{
    public interface IDeleteCategoryContentOutputPort
    {
        Task Handle(CategoryContentsDTO categoryContent);
    }
}

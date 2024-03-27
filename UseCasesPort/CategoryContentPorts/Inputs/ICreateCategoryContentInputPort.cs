using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Inputs
{
    public interface ICreateCategoryContentInputPort
    {
        Task Handle(CreateCategoryContentDTO categoryContent);
    }
}

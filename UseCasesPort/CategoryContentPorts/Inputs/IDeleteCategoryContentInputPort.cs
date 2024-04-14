using DTOs.CategoryContentDTO;

namespace UseCasesPort.CategoryContentPorts.Inputs
{
    public interface IDeleteCategoryContentInputPort
    {
        Task Handle(int IdCategoryContent);
    }
}

using DTOs.CategoryDTO;

namespace UseCasesPort.CategoryPorts.Inputs
{
    public interface IDeleteCategoryInputPort
    {
        Task Handle(int IdCategory);
    }
}

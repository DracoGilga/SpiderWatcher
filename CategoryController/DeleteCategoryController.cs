using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace CategoryController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeleteCategoryController
    {
        readonly IDeleteCategoryInputPort InputPort;
        readonly IDeleteCategoryOutputPort OutputPort;

        public DeleteCategoryController(IDeleteCategoryInputPort inputPort,
            IDeleteCategoryOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("{IdCategory}")]
        public async Task<CategoriesDTO> DeleteCategory(int IdCategory)
        {
            await InputPort.Handle(IdCategory);
            return ((DeleteCategoryPresenter)OutputPort).Content;
        }
    }
}

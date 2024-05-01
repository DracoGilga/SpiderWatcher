using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace CategoryController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CreateCategoryController
    {
        readonly ICreateCategoryInputPort InputPort;
        readonly ICreateCategoryOutputPort OutputPort;

        public CreateCategoryController(ICreateCategoryInputPort inputPort,
                                                    ICreateCategoryOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CategoriesDTO> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            await InputPort.Handle(categoryDTO);
            return ((CreateCategoryPresenter)OutputPort).Content;
        }
    }
}

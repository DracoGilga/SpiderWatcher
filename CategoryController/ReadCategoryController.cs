using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace CategoryController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReadCategoryController
    {
        readonly IReadCategoryInputPort InputPort;
        readonly IReadCategoryOutputPort OutputPort;

        public ReadCategoryController(IReadCategoryInputPort inputPort,
            IReadCategoryOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdCategory}")]
        public async Task<ReadCategoryDTO> ReadCategory(int IdCategory)
        {
            await InputPort.Handle(IdCategory);
            return ((ReadCategoryPresenter)OutputPort).Content;
        }
    }
}

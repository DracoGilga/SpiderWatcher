using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace Controler.Category
{
    [Route("[Controller]")]
    [ApiController]
    public class UpdateCategoryController
    {
        readonly IUpdateCategoryInputPort InputPort;
        readonly IUpdateCategoryOutputPort OutputPort;

        public UpdateCategoryController(IUpdateCategoryInputPort inputPort,
            IUpdateCategoryOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdateCategoryDTO> UpdateCategory (UpdateCategoryDTO categoryDTO)
        {
            await InputPort.Handle(categoryDTO);
            return ((UpdateCategoryPresenter)OutputPort).Content;
        }
    }
}

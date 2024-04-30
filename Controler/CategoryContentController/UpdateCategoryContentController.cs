using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Controler.CategoryContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UpdateCategoryContentController
    {
        readonly IUpdateCategoryContentInputPort InputPort;
        readonly IUpdateCategoryContentOutputPort OutputPort;

        public UpdateCategoryContentController(IUpdateCategoryContentInputPort inputPort,
                       IUpdateCategoryContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdateCategoryContentDTO> UpdateCategoryContent(UpdateCategoryContentDTO categoryContentDTO)
        {
            await InputPort.Handle(categoryContentDTO);
            return ((UpdateCategoryContentPresenter)OutputPort).Content;
        }
    }
}

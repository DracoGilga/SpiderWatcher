using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Controler.CategoryContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CreateCategoryContentController
    {
        readonly ICreateCategoryContentInputPort InputPort;
        readonly ICreateCategoryContentOutputPort OutputPort;

        public CreateCategoryContentController(ICreateCategoryContentInputPort inputPort, 
                                                     ICreateCategoryContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CategoryContentsDTO> CreateCategoryContent(CreateCategoryContentDTO categoryContentDTO)
        {
            await InputPort.Handle(categoryContentDTO);
            return ((CreateCategoryContentPresenter)OutputPort).Content;
        }
    }
}

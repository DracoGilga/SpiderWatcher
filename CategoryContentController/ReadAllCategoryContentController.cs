using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace CategoryContentController
{
    [Route("[Controller]")]
    [ApiController]
    public class ReadAllCategoryContentController
    {
        readonly IReadAllCategoryContentInputPort InputPort;
        readonly IReadAllCategoryContentOutputPort OutputPort;

        public ReadAllCategoryContentController(IReadAllCategoryContentInputPort inputPort,
                       IReadAllCategoryContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IEnumerable<ReadCategoryContentDTO>> ReadAllCategoryContent()
        {
            await InputPort.Handle();
            return ((ReadAllCategoryContentPresenter)OutputPort).Content;
        }
    }
}

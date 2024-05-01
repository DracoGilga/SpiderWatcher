using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace CategoryContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReadCategoryContentController
    {
        readonly IReadCategoryContentInputPort InputPort;
        readonly IReadCategoryContentOutputPort OutputPort;

        public ReadCategoryContentController(IReadCategoryContentInputPort inputPort,
            IReadCategoryContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdCategoryContent}")]
        public async Task<ReadCategoryContentDTO> ReadCategoryContent(int IdCategoryContent)
        {
            await InputPort.Handle(IdCategoryContent);
            return ((ReadCategoryContentPresenter)OutputPort).Content;
        }
    }
}

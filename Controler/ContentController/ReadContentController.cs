using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReadContentController
    {
        readonly IReadContentInputPort InputPort;
        readonly IReadContentOutputPort OutputPort;

        public ReadContentController(IReadContentInputPort inputPort,
            IReadContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdContent}")]
        public async Task<ReadContentDTO> ReadContent(int IdContent)
        {
            await InputPort.Handle(IdContent);
            return ((ReadContentPresenter)OutputPort).Content;
        }

    }
}

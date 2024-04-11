using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReadAllContentController
    {
        readonly IReadAllContentInputPort InputPort;
        readonly IReadAllContentOutputPort OutputPort;

        public ReadAllContentController(IReadAllContentInputPort inputPort, 
            IReadAllContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IEnumerable<ContentsDTO>> ReadAllContent()
        {
            await InputPort.Handle();
            return ((ReadAllContentPresenter)OutputPort).Content;
        }
    }
}

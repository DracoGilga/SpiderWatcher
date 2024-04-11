using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ViewContentController
    {
        readonly IViewContentInputPort InputPort;
        readonly IViewContentOutputPort OutputPort;

        public ViewContentController(IViewContentInputPort inputPort,
            IViewContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdContent}")]
        public async Task<ViewContentDTO> ViewContent(int IdContent)
        {
            await InputPort.Handle(IdContent);
            return ((ViewContentPresenter)OutputPort).Content;
        }
    }
}

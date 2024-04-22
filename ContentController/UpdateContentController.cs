using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UpdateContentController
    {
        readonly IUpdateContentInputPort InputPort;
        readonly IUpdateContentOutputPort OutputPort;

        public UpdateContentController(IUpdateContentInputPort inputPort,
                       IUpdateContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdateContentDTO> UpdateContent(UpdateContentDTO contentDTO)
        {
            await InputPort.Handle(contentDTO);
            return ((UpdateContentPresenter)OutputPort).Content;
        }
    }
}

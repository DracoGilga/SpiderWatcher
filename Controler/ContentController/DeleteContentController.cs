using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeleteContentController
    {
        readonly IDeleteContentInputPort InputPort;
        readonly IDeleteContentOutputPort OutputPort;

        public DeleteContentController(IDeleteContentInputPort inputPort, 
                                             IDeleteContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("{IdContent}")]
        public async Task<ContentsDTO> DeleteContent(int IdContent)
        {
            await InputPort.Handle(IdContent);
            return ((DeleteContentPresenter)OutputPort).Content;
        }
    }
}

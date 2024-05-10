using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace Controler.ContentController
{
    [Route("[Controller]")]
    [ApiController]
    public class CreateContentController
    {
        readonly ICreateContentInputPort InputPort;
        readonly ICreateContentOutputPort OutputPort;

        public CreateContentController(ICreateContentInputPort inputPort, 
                                  ICreateContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CreateContentDTO> CreateContent(CreateContentDTO contentDTO)
        {
            await InputPort.Handle(contentDTO);
            return ((CreateContentPresenter)OutputPort).Content;
        }
    }
}

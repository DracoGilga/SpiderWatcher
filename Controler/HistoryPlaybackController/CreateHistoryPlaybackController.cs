using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Controler.HistoryPlaybackController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CreateHistoryPlaybackController
    {
        readonly ICreateHistoryPlaybackInputPort InputPort;
        readonly ICreateHistoryPlaybackOutputPort OutputPort;

        public CreateHistoryPlaybackController(ICreateHistoryPlaybackInputPort inputPort, 
                       ICreateHistoryPlaybackOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CreateHistoryPlaybackDTO> CreateHistoryPlayback(CreateHistoryPlaybackDTO historyPlaybackDTO)
        {
            await InputPort.Handle(historyPlaybackDTO);
            return ((CreateHistoryPlaybackPresenter)OutputPort).Content;
        }
    }
}

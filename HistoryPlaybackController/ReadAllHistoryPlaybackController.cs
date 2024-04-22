using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Controler.HistoryPlaybackController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReadAllHistoryPlaybackController
    {
        readonly IReadAllHistoryPlaybackInputPort InputPort;
        readonly IReadAllHistoryPlaybackOutputPort OutputPort;

        public ReadAllHistoryPlaybackController(IReadAllHistoryPlaybackInputPort inputPort, 
                                             IReadAllHistoryPlaybackOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IEnumerable<HistoryPlaybacksDTO>> ReadAllHistoryPlayback()
        {
            await InputPort.Handle();
            return ((ReadAllHistoryPlaybackPresenter)OutputPort).Content;
        }
    }
}

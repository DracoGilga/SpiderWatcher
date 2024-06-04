using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Controler.HistoryPlaybackController
{
    [Route("[Controller]")]
    [ApiController]
    public class ReadHistoryPlaybackController
    {
        readonly IReadHistoryPlaybackInputPort InputPort;
        readonly IReadHistoryPlaybackOutputPort OutputPort;

        public ReadHistoryPlaybackController(IReadHistoryPlaybackInputPort inputPort,
            IReadHistoryPlaybackOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdHistoryPlayback}")]
        public async Task<ReadHistoryPlaybackDTO> ReadHistoryPlayback(int IdHistoryPlayback)
        {
            await InputPort.Handle(IdHistoryPlayback);
            return ((ReadHistoryPlaybackPresenter)OutputPort).Content;
        }
    }
}

using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Controler.HistoryPlaybackController
{
    [Route("[Controller]")]
    [ApiController]
    public class UpdateHistoryPlaybackController
    {
        readonly IUpdateHistoryPlaybackInputPort InputPort;
        readonly IUpdateHistoryPlaybackOutputPort OutputPort;

        public UpdateHistoryPlaybackController(IUpdateHistoryPlaybackInputPort inputPort,
            IUpdateHistoryPlaybackOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdateHistoryPlaybackDTO> UpdateHistoryPlayback(UpdateHistoryPlaybackDTO historyPlaybackDTO)
        {
            await InputPort.Handle(historyPlaybackDTO);
            return ((UpdadeHistoryPlaybackPresenter)OutputPort).Content;
        }
    }
}

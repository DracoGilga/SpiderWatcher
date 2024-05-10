using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace Controler.HistoryPlaybackController
{
    [Route("[Controller]")]
    [ApiController]
    public class DeleteHistoryPlaybackController
    {
        readonly IDeleteHistoryPlaybackInputPort InputPort;
        readonly IDeleteHistoryPlaybackOutputPort OutputPort;

        public DeleteHistoryPlaybackController(IDeleteHistoryPlaybackInputPort inputPort, 
                                  IDeleteHistoryPlaybackOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("{IdHistoryPlayback}")]
        public async Task<HistoryPlaybacksDTO> DeleteHistoryPlayback(int IdHistoryPlayback)
        {
            await InputPort.Handle(IdHistoryPlayback);
            return ((DeleteHistoryPlaybackPresenter)OutputPort).Content;
        }
    }
}

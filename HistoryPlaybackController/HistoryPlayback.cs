using DTOs.HistoryPlaybackDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.HistoryPlayback;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace HistoryPlaybackController
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryPlayback : ControllerBase
    {
        private readonly ICreateHistoryPlaybackInputPort CreateHistoryPlaybackInputPort;
        private readonly ICreateHistoryPlaybackOutputPort CreateHistoryPlaybackOutputPort;
        private readonly IDeleteHistoryPlaybackInputPort DeleteHistoryPlaybackInputPort;
        private readonly IDeleteHistoryPlaybackOutputPort DeleteHistoryPlaybackOutputPort;
        private readonly IReadAllHistoryPlaybackInputPort ReadAllHistoryPlaybackInputPort;
        private readonly IReadAllHistoryPlaybackOutputPort ReadAllHistoryPlaybackOutputPort;
        private readonly IReadHistoryPlaybackInputPort ReadHistoryPlaybackInputPort;
        private readonly IReadHistoryPlaybackOutputPort ReadHistoryPlaybackOutputPort;
        private readonly IUpdateHistoryPlaybackInputPort UpdateHistoryPlaybackInputPort;
        private readonly IUpdateHistoryPlaybackOutputPort UpdateHistoryPlaybackOutputPort;

        public HistoryPlayback(
            ICreateHistoryPlaybackInputPort createHistoryPlaybackInputPort,
            ICreateHistoryPlaybackOutputPort createHistoryPlaybackOutputPort,
            IDeleteHistoryPlaybackInputPort deleteHistoryPlaybackInputPort,
            IDeleteHistoryPlaybackOutputPort deleteHistoryPlaybackOutputPort,
            IReadAllHistoryPlaybackInputPort readAllHistoryPlaybackInputPort,
            IReadAllHistoryPlaybackOutputPort readAllHistoryPlaybackOutputPort,
            IReadHistoryPlaybackInputPort readHistoryPlaybackInputPort,
            IReadHistoryPlaybackOutputPort readHistoryPlaybackOutputPort,
            IUpdateHistoryPlaybackInputPort updateHistoryPlaybackInputPort,
            IUpdateHistoryPlaybackOutputPort updateHistoryPlaybackOutputPort)
        {
            CreateHistoryPlaybackInputPort = createHistoryPlaybackInputPort;
            CreateHistoryPlaybackOutputPort = createHistoryPlaybackOutputPort;
            DeleteHistoryPlaybackInputPort = deleteHistoryPlaybackInputPort;
            DeleteHistoryPlaybackOutputPort = deleteHistoryPlaybackOutputPort;
            ReadAllHistoryPlaybackInputPort = readAllHistoryPlaybackInputPort;
            ReadAllHistoryPlaybackOutputPort = readAllHistoryPlaybackOutputPort;
            ReadHistoryPlaybackInputPort = readHistoryPlaybackInputPort;
            ReadHistoryPlaybackOutputPort = readHistoryPlaybackOutputPort;
            UpdateHistoryPlaybackInputPort = updateHistoryPlaybackInputPort;
            UpdateHistoryPlaybackOutputPort = updateHistoryPlaybackOutputPort;
        }

        [HttpPost]
        public async Task<ActionResult<CreateHistoryPlaybackDTO>> Create(CreateHistoryPlaybackDTO historyPlaybackDTO)
        {
            await CreateHistoryPlaybackInputPort.Handle(historyPlaybackDTO);
            return ((CreateHistoryPlaybackPresenter)CreateHistoryPlaybackOutputPort).Content;
        }

        [HttpDelete("{idHistoryPlayback}")]
        public async Task<ActionResult<HistoryPlaybacksDTO>> Delete(int idHistoryPlayback)
        {
            await DeleteHistoryPlaybackInputPort.Handle(idHistoryPlayback);
            return ((DeleteHistoryPlaybackPresenter)DeleteHistoryPlaybackOutputPort).Content;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryPlaybacksDTO>>> ReadAll()
        {
            await ReadAllHistoryPlaybackInputPort.Handle();
            return Ok(((ReadAllHistoryPlaybackPresenter)ReadAllHistoryPlaybackOutputPort).Content);
        }

        [HttpGet("{idHistoryPlayback}")]
        public async Task<ActionResult<ReadHistoryPlaybackDTO>> Read(int idHistoryPlayback)
        {
            await ReadHistoryPlaybackInputPort.Handle(idHistoryPlayback);
            return ((ReadHistoryPlaybackPresenter)ReadHistoryPlaybackOutputPort).Content;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateHistoryPlaybackDTO>> Update(UpdateHistoryPlaybackDTO historyPlaybackDTO)
        {
            await UpdateHistoryPlaybackInputPort.Handle(historyPlaybackDTO);
            return ((UpdadeHistoryPlaybackPresenter)UpdateHistoryPlaybackOutputPort).Content;
        }
    }
}

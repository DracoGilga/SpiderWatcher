using DTOs.ContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Content;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentController
{
    [Route("[controller]")]
    [ApiController]
    public class Content : ControllerBase
    {
        private readonly ICreateContentInputPort CreateContentInputPort;
        private readonly ICreateContentOutputPort CreateContentOutputPort;
        private readonly IDeleteContentInputPort DeleteContentInputPort;
        private readonly IDeleteContentOutputPort DeleteContentOutputPort;
        private readonly IReadAllContentInputPort ReadAllContentInputPort;
        private readonly IReadAllContentOutputPort ReadAllContentOutputPort;
        private readonly IReadContentInputPort ReadContentInputPort;
        private readonly IReadContentOutputPort ReadContentOutputPort;
        private readonly IUpdateContentInputPort UpdateContentInputPort;
        private readonly IUpdateContentOutputPort UpdateContentOutputPort;
        private readonly IViewContentInputPort ViewContentInputPort;
        private readonly IViewContentOutputPort ViewContentOutputPort;

        public Content(
            ICreateContentInputPort createContentInputPort,
            ICreateContentOutputPort createContentOutputPort,
            IDeleteContentInputPort deleteContentInputPort,
            IDeleteContentOutputPort deleteContentOutputPort,
            IReadAllContentInputPort readAllContentInputPort,
            IReadAllContentOutputPort readAllContentOutputPort,
            IReadContentInputPort readContentInputPort,
            IReadContentOutputPort readContentOutputPort,
            IUpdateContentInputPort updateContentInputPort,
            IUpdateContentOutputPort updateContentOutputPort,
            IViewContentInputPort viewContentInputPort,
            IViewContentOutputPort viewContentOutputPort)
        {
            CreateContentInputPort = createContentInputPort;
            CreateContentOutputPort = createContentOutputPort;
            DeleteContentInputPort = deleteContentInputPort;
            DeleteContentOutputPort = deleteContentOutputPort;
            ReadAllContentInputPort = readAllContentInputPort;
            ReadAllContentOutputPort = readAllContentOutputPort;
            ReadContentInputPort = readContentInputPort;
            ReadContentOutputPort = readContentOutputPort;
            UpdateContentInputPort = updateContentInputPort;
            UpdateContentOutputPort = updateContentOutputPort;
            ViewContentInputPort = viewContentInputPort;
            ViewContentOutputPort = viewContentOutputPort;
        }

        [HttpPost]
        public async Task<ActionResult<CreateContentDTO>> Create(CreateContentDTO contentDTO)
        {
            await CreateContentInputPort.Handle(contentDTO);
            return ((CreateContentPresenter)CreateContentOutputPort).Content;
        }

        [HttpDelete("{idContent}")]
        public async Task<ActionResult<ContentsDTO>> Delete(int idContent)
        {
            await DeleteContentInputPort.Handle(idContent);
            return ((DeleteContentPresenter)DeleteContentOutputPort).Content;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentsDTO>>> ReadAll()
        {
            await ReadAllContentInputPort.Handle();
            return Ok(((ReadAllContentPresenter)ReadAllContentOutputPort).Content);
        }

        [HttpGet("{idContent}")]
        public async Task<ActionResult<ReadContentDTO>> Read(int idContent)
        {
            await ReadContentInputPort.Handle(idContent);
            return ((ReadContentPresenter)ReadContentOutputPort).Content;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateContentDTO>> Update(UpdateContentDTO contentDTO)
        {
            await UpdateContentInputPort.Handle(contentDTO);
            return ((UpdateContentPresenter)UpdateContentOutputPort).Content;
        }

        [HttpGet("View/{idContent}")]
        public async Task<ActionResult<ViewContentDTO>> View(int idContent)
        {
            await ViewContentInputPort.Handle(idContent);
            return ((ViewContentPresenter)ViewContentOutputPort).Content;
        }
    }
}

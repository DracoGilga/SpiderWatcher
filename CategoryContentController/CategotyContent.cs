using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace CategoryContentController
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryContent : ControllerBase
    {
        private readonly ICreateCategoryContentInputPort CreateCategoryContentInputPort;
        private readonly ICreateCategoryContentOutputPort CreateCategoryContentOutputPort;
        private readonly IUpdateCategoryContentInputPort UpdateCategoryContentInputPort;
        private readonly IUpdateCategoryContentOutputPort UpdateCategoryContentOutputPort;
        private readonly IReadCategoryContentInputPort ReadCategoryContentInputPort;
        private readonly IReadCategoryContentOutputPort ReadCategoryContentOutputPort;
        private readonly IReadAllCategoryContentInputPort ReadAllCategoryContentInputPort;
        private readonly IReadAllCategoryContentOutputPort ReadAllCategoryContentOutputPort;
        private readonly IDeleteCategoryContentInputPort DeleteCategoryContentInputPort;
        private readonly IDeleteCategoryContentOutputPort DeleteCategoryContentOutputPort;

        public CategoryContent(
            ICreateCategoryContentInputPort createCategoryContentInputPort,
            ICreateCategoryContentOutputPort createCategoryContentOutputPort,
            IUpdateCategoryContentInputPort updateCategoryContentInputPort,
            IUpdateCategoryContentOutputPort updateCategoryContentOutputPort,
            IReadCategoryContentInputPort readCategoryContentInputPort,
            IReadCategoryContentOutputPort readCategoryContentOutputPort,
            IReadAllCategoryContentInputPort readAllCategoryContentInputPort,
            IReadAllCategoryContentOutputPort readAllCategoryContentOutputPort,
            IDeleteCategoryContentInputPort deleteCategoryContentInputPort,
            IDeleteCategoryContentOutputPort deleteCategoryContentOutputPort)
        {
            CreateCategoryContentInputPort = createCategoryContentInputPort;
            CreateCategoryContentOutputPort = createCategoryContentOutputPort;
            UpdateCategoryContentInputPort = updateCategoryContentInputPort;
            UpdateCategoryContentOutputPort = updateCategoryContentOutputPort;
            ReadCategoryContentInputPort = readCategoryContentInputPort;
            ReadCategoryContentOutputPort = readCategoryContentOutputPort;
            ReadAllCategoryContentInputPort = readAllCategoryContentInputPort;
            ReadAllCategoryContentOutputPort = readAllCategoryContentOutputPort;
            DeleteCategoryContentInputPort = deleteCategoryContentInputPort;
            DeleteCategoryContentOutputPort = deleteCategoryContentOutputPort;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryContentsDTO>> Create(CreateCategoryContentDTO categoryContentDTO)
        {
            await CreateCategoryContentInputPort.Handle(categoryContentDTO);
            return ((CreateCategoryContentPresenter)CreateCategoryContentOutputPort).Content;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCategoryContentDTO>> Update(UpdateCategoryContentDTO categoryContentDTO)
        {
            await UpdateCategoryContentInputPort.Handle(categoryContentDTO);
            return ((UpdateCategoryContentPresenter)UpdateCategoryContentOutputPort).Content;
        }

        [HttpGet("{IdCategoryContent}")]
        public async Task<ActionResult<ReadCategoryContentDTO>> Read(int IdCategoryContent)
        {
            await ReadCategoryContentInputPort.Handle(IdCategoryContent);
            return ((ReadCategoryContentPresenter)ReadCategoryContentOutputPort).Content;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCategoryContentDTO>>> ReadAll()
        {
            await ReadAllCategoryContentInputPort.Handle();
            return Ok(((ReadAllCategoryContentPresenter)ReadAllCategoryContentOutputPort).Content);
        }

        [HttpDelete("{IdCategoryContent}")]
        public async Task<ActionResult<CategoryContentsDTO>> Delete(int IdCategoryContent)
        {
            await DeleteCategoryContentInputPort.Handle(IdCategoryContent);
            return ((DeleteCategoryContentPresenter)DeleteCategoryContentOutputPort).Content;
        }
    }
}

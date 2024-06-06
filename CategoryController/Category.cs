using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryController
{
    [Route("[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly ICreateCategoryInputPort CreateCategoryInputPort;
        private readonly ICreateCategoryOutputPort CreateCategoryOutputPort;
        private readonly IUpdateCategoryInputPort UpdateCategoryInputPort;
        private readonly IUpdateCategoryOutputPort UpdateCategoryOutputPort;
        private readonly IReadCategoryInputPort ReadCategoryInputPort;
        private readonly IReadCategoryOutputPort ReadCategoryOutputPort;
        private readonly IReadAllCategoryInputPort ReadAllCategoryInputPort;
        private readonly IReadAllCategoryOutputPort ReadAllCategoryOutputPort;
        private readonly IDeleteCategoryInputPort DeleteCategoryInputPort;
        private readonly IDeleteCategoryOutputPort DeleteCategoryOutputPort;

        public Category(
            ICreateCategoryInputPort createCategoryInputPort,
            ICreateCategoryOutputPort createCategoryOutputPort,
            IUpdateCategoryInputPort updateCategoryInputPort,
            IUpdateCategoryOutputPort updateCategoryOutputPort,
            IReadCategoryInputPort readCategoryInputPort,
            IReadCategoryOutputPort readCategoryOutputPort,
            IReadAllCategoryInputPort readAllCategoryInputPort,
            IReadAllCategoryOutputPort readAllCategoryOutputPort,
            IDeleteCategoryInputPort deleteCategoryInputPort,
            IDeleteCategoryOutputPort deleteCategoryOutputPort)
        {
            CreateCategoryInputPort = createCategoryInputPort;
            CreateCategoryOutputPort = createCategoryOutputPort;
            UpdateCategoryInputPort = updateCategoryInputPort;
            UpdateCategoryOutputPort = updateCategoryOutputPort;
            ReadCategoryInputPort = readCategoryInputPort;
            ReadCategoryOutputPort = readCategoryOutputPort;
            ReadAllCategoryInputPort = readAllCategoryInputPort;
            ReadAllCategoryOutputPort = readAllCategoryOutputPort;
            DeleteCategoryInputPort = deleteCategoryInputPort;
            DeleteCategoryOutputPort = deleteCategoryOutputPort;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriesDTO>> Create(CreateCategoryDTO categoryDTO)
        {
            await CreateCategoryInputPort.Handle(categoryDTO);
            return ((CreateCategoryPresenter)CreateCategoryOutputPort).Content;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCategoryDTO>> Update(UpdateCategoryDTO categoryDTO)
        {
            await UpdateCategoryInputPort.Handle(categoryDTO);
            return ((UpdateCategoryPresenter)UpdateCategoryOutputPort).Content;
        }

        [HttpGet("{IdCategory}")]
        public async Task<ActionResult<ReadCategoryDTO>> Read(int IdCategory)
        {
            await ReadCategoryInputPort.Handle(IdCategory);
            return ((ReadCategoryPresenter)ReadCategoryOutputPort).Content;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCategoryDTO>>> ReadAll()
        {
            await ReadAllCategoryInputPort.Handle();
            return Ok(((ReadAllCategoryPresenter)ReadAllCategoryOutputPort).Content);
        }

        [HttpDelete("{IdCategory}")]
        public async Task<ActionResult<CategoriesDTO>> Delete(int IdCategory)
        {
            await DeleteCategoryInputPort.Handle(IdCategory);
            return ((DeleteCategoryPresenter)DeleteCategoryOutputPort).Content;
        }
    }
}

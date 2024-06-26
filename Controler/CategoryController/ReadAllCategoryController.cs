﻿using DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.Category;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.CategoryPorts.Outputs;

namespace Controler.Category
{
    [Route("[Controller]")]
    [ApiController]
    public class ReadAllCategoryController
    {
        readonly IReadAllCategoryInputPort InputPort;
        readonly IReadAllCategoryOutputPort OutputPort;

        public ReadAllCategoryController(IReadAllCategoryInputPort inputPort,
            IReadAllCategoryOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IEnumerable<ReadCategoryDTO>> ReadAllCategory()
        {
            await InputPort.Handle();
            return ((ReadAllCategoryPresenter)OutputPort).Content;
        }
    }
}

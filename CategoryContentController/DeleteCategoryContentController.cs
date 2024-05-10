using DTOs.CategoryContentDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.CategoryContent;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace CategoryContentController
{
    [Route("[Controller]")]
    [ApiController]
    public class DeleteCategoryContentController
    {
        readonly IDeleteCategoryContentInputPort InputPort;
        readonly IDeleteCategoryContentOutputPort OutputPort;

        public DeleteCategoryContentController(IDeleteCategoryContentInputPort inputPort,
                                             IDeleteCategoryContentOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("{IdCategoryContent}")]
        public async Task<CategoryContentsDTO> DeleteCategoryContent(int IdCategoryContent)
        {
            await InputPort.Handle(IdCategoryContent);
            return ((DeleteCategoryContentPresenter)OutputPort).Content;
        }
    }
}

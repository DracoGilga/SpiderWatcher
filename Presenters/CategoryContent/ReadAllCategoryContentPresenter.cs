using DTOs.CategoryContentDTO;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.CategoryContent
{
    internal class ReadAllCategoryContentPresenter : 
        IReadAllCategoryContentOutputPort, IPresenter<IEnumerable<ReadCategoryContentDTO>>
    {
        public IEnumerable<ReadCategoryContentDTO> Content { get; private set; }

        public Task Handle(IEnumerable<ReadCategoryContentDTO> categoryContent)
        {
            Content = categoryContent;
            return Task.CompletedTask;
        }
    }
}

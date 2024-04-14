using DTOs.CategoryContentDTO;
using UseCasesPort.CategoryContentPorts.Outputs;

namespace Presenters.CategoryContent
{
    public class ReadCategoryContentPresenter :
        IReadCategoryContentOutputPort, IPresenter<ReadCategoryContentDTO>
    {
        public ReadCategoryContentDTO Content { get; private set; }

        public Task Handle(ReadCategoryContentDTO categoryContent)
        {
            Content = categoryContent;
            return Task.CompletedTask;
        }
    }
}

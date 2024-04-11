using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class ViewContentPresenter : IViewContentOutputPort, IPresenter<ViewContentDTO>
    {
        public ViewContentDTO Content { get; private set;}

        public Task Handle(ViewContentDTO content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

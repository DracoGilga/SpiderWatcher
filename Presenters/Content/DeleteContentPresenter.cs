using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class DeleteContentPresenter :
        IDeleteContentOutputPort, IPresenter<ContentsDTO>
    {
        public ContentsDTO Content { get; private set; }

        public Task Handle(ContentsDTO content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

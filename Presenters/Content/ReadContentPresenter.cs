using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class ReadContentPresenter :
        IReadContentOutputPort, IPresenter<ReadContentDTO>
    {
        public ReadContentDTO Content { get; private set;}

        public Task Handle(ReadContentDTO content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

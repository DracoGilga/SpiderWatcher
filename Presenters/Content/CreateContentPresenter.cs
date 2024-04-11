using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class CreateContentPresenter :
        ICreateContentOutputPort, IPresenter<CreateContentDTO>
    {
        public CreateContentDTO Content { get; private set;}

        public Task Handle(CreateContentDTO content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class UpdateContentPresenter : IUpdateContentOutputPort, IPresenter<UpdateContentDTO>
    {
        public UpdateContentDTO Content { get; private set;}

        public Task Handle(UpdateContentDTO content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

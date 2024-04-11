using DTOs.ContentDTO;
using UseCasesPort.ContentPorts.Outputs;

namespace Presenters.Content
{
    public class ReadAllContentPresenter : 
        IReadAllContentOutputPort, IPresenter<IEnumerable<ContentsDTO>>
    {
        public IEnumerable<ContentsDTO> Content { get; private set; }

        public Task Handle(IEnumerable<ContentsDTO> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}

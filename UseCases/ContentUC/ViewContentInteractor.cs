using DTOs.ContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class ViewContentInteractor : IViewContentInputPort
    {
        readonly IContentRepository repository;
        readonly IViewContentOutputPort outputPort;

        public ViewContentInteractor(IContentRepository repository, IViewContentOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public async Task Handle(int IdContent)
        {
            Content NewContent = new()
            {
                ContentId = IdContent
            };
            Content Content = repository.ReadContent(NewContent.ContentId);
            await outputPort.Handle(
                new ViewContentDTO
                {
                    IdContent = Content.ContentId,
                    Title = Content.Title,
                    VideoReference = Content.VideoReference
                });
        }
    }
}

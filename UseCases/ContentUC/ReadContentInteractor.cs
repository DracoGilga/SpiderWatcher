using DTOs.ContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class ReadContentInteractor : IReadContentInputPort
    {
        readonly IContentRepository repository;
        readonly IReadContentOutputPort outputPort;

        public ReadContentInteractor(IContentRepository repository, IReadContentOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public async Task Handle(int IdCsontent)
        {
            Content NewContent = new()
            {
                ContentId = IdCsontent
            };
            Content Content = repository.ReadContent(NewContent.ContentId);
            await outputPort.Handle(
                new ReadContentDTO
                {
                    IdContent = Content.ContentId,
                    Title = Content.Title,
                    Director = Content.Director,
                    Description = Content.Description,
                    ReleaseDate = Content.ReleaseDate,
                    PublicationDate = Content.PublicationDate,
                    Duration = Content.Duration,
                    Rating = Content.Rating,
                    VideoReference = Content.VideoReference,
                    ImageReference = Content.ImageReference
                });
        }
    }
}

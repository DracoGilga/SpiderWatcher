using DTOs.ContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class CreateContentInteractor : ICreateContentInputPort
    {
        readonly IContentRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateContentOutputPort OutputPort;

        public CreateContentInteractor(IContentRepository repository, 
                                  IUnitOfWork unitOfWork, ICreateContentOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(CreateContentDTO content)
        {
            Content NewContent = new()
            {
                Title = content.Title,
                Director = content.Director,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                PublicationDate = content.PublicationDate,
                Duration = content.Duration,
                Rating = content.Rating,
                ImageReference = content.ImageReference,
                VideoReference = content.VideoReference
            };

            Repository.CreateContent(NewContent);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new CreateContentDTO
                {
                    Title = NewContent.Title,
                    Director = NewContent.Director,
                    Description = NewContent.Description,
                    ReleaseDate = NewContent.ReleaseDate,
                    PublicationDate = NewContent.PublicationDate,
                    Duration = NewContent.Duration,
                    Rating = NewContent.Rating,
                    ImageReference = NewContent.ImageReference,
                    VideoReference = NewContent.VideoReference
                });
        }
    }
}

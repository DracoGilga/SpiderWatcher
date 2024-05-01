using DTOs.ContentDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class UpdateContentInteractor : IUpdateContentInputPort
    {
        readonly IContentRepository ContentRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateContentOutputPort OutputPort;

        public UpdateContentInteractor(IContentRepository contentRepository,
            IUnitOfWork unitOfWork, IUpdateContentOutputPort outputPort) =>
            (ContentRepository, UnitOfWork, OutputPort) =
            (contentRepository, unitOfWork, outputPort);

        public async Task Handle(UpdateContentDTO content)
        {
            Content existingContent = ContentRepository.ReadContent(content.IdContent);
            if (existingContent != null)
            {
                if (!string.IsNullOrEmpty(content.Title))
                    existingContent.Title = content.Title;

                if (!string.IsNullOrEmpty(content.Director))
                    existingContent.Director = content.Director;
                
                if (!string.IsNullOrEmpty(content.Description))
                    existingContent.Description = content.Description;

                if (content.ReleaseDate != null && content.ReleaseDate != existingContent.ReleaseDate)
                    existingContent.ReleaseDate = content.ReleaseDate;

                if (content.Duration != null && content.Duration != existingContent.Duration)
                    existingContent.Duration = content.Duration;

                if (!string.IsNullOrEmpty(content.ImageReference))
                    existingContent.ImageReference = content.ImageReference;

                bool success = ContentRepository.UpdateContent(existingContent);
                if (success)
                {
                    await UnitOfWork.SaveChanges();
                    await OutputPort.Handle(
                        new UpdateContentDTO
                        {
                            IdContent = existingContent.ContentId,
                            Title = existingContent.Title,
                            Director = existingContent.Director,
                            Description = existingContent.Description,
                            ReleaseDate = existingContent.ReleaseDate,
                            Duration = existingContent.Duration,
                            ImageReference = existingContent.ImageReference,
                            VideoReference = existingContent.VideoReference
                        });
                }
            }
        }
    }
}

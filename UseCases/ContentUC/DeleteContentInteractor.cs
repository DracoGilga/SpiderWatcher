using DTOs.ContentDTO;
using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class DeleteContentInteractor : IDeleteContentInputPort
    {
        readonly IContentRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteContentOutputPort OutputPort;

        public DeleteContentInteractor(IContentRepository repository, 
            IUnitOfWork unitOfWork, IDeleteContentOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(int IdContent)
        {
            Content NewContent = new()
            {
                ContentId = IdContent
            };
            var result = Repository.DeleteContent(NewContent.ContentId);
            await UnitOfWork.SaveChanges();
            if (result != null)
            {
                await OutputPort.Handle(
                    new ContentsDTO
                    {
                        IdContent = result.ContentId,
                        Title = result.Title,
                        ImageReference = result.ImageReference
                    }
                );
            }
        }
    }
}

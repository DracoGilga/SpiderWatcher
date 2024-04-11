using DTOs.ContentDTO;
using Entities.Interface;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.ContentPorts.Outputs;

namespace UseCases.ContentUC
{
    public class ReadAllContentInteractor : IReadAllContentInputPort
    {
        readonly IContentRepository repository;
        readonly IReadAllContentOutputPort outputPort;

        public ReadAllContentInteractor(IContentRepository repository, IReadAllContentOutputPort outputPort) =>
            (this.repository, this.outputPort) = (repository, outputPort);

        public Task Handle()
        {
            var contents = repository.ReadAllContents().Select(p =>
                new ContentsDTO
                {
                    IdContent = p.ContentId,
                    Title = p.Title,
                    ImageReference = p.ImageReference
                });
            outputPort.Handle(contents);
            return Task.CompletedTask;
        }
    }
}

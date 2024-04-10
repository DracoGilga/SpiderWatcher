using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace UseCases.HystoryPlaybackUC
{
    public class CreateHistoryPlaybackInteractor : ICreateHistoryPlaybackInputPort
    {
        readonly IHistoryPlaybackRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateHistoryPlaybackOutputPort OutputPort;

        public CreateHistoryPlaybackInteractor(IHistoryPlaybackRepository repository, 
                       IUnitOfWork unitOfWork, ICreateHistoryPlaybackOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(CreateHistoryPlaybackDTO historyPlayback)
        {
            HistoryPlayback NewHistoryPlayback = new()
            {
                UserId = historyPlayback.IdUser,
                ContentId = historyPlayback.IdContent,
                PlaybackTime = historyPlayback.PlaybackTime,
                PlaybackDate = historyPlayback.PlaybackDate
            };

            Repository.CreateHistoryPlayback(NewHistoryPlayback);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new CreateHistoryPlaybackDTO
                {
                    IdUser = NewHistoryPlayback.UserId,
                    IdContent = NewHistoryPlayback.ContentId,
                    PlaybackTime = NewHistoryPlayback.PlaybackTime,
                    PlaybackDate = NewHistoryPlayback.PlaybackDate
                });
        }
    }
}

using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace UseCases.HystoryPlaybackUC
{
    public class UpdateHistoryPlaybackInteractor : IUpdateHistoryPlaybackInputPort
    {
        readonly IHistoryPlaybackRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateHistoryPlaybackOutputPort OutputPort;

        public UpdateHistoryPlaybackInteractor(IHistoryPlaybackRepository repository, 
                       IUnitOfWork unitOfWork, IUpdateHistoryPlaybackOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(UpdateHistoryPlaybackDTO historyPlayback)
        {
            HistoryPlayback existingUserHistoryPlayback = Repository.ReadHistoryPlayback(historyPlayback.IdHistory);
            if (existingUserHistoryPlayback != null)
            {
                if (!int.IsPositive(historyPlayback.IdUser))
                    existingUserHistoryPlayback.UserId = historyPlayback.IdUser;
                
                if (!int.IsPositive(historyPlayback.IdContent))
                    existingUserHistoryPlayback.ContentId = historyPlayback.IdContent;
                
                if (existingUserHistoryPlayback.PlaybackTime != historyPlayback.PlaybackTime)
                    existingUserHistoryPlayback.PlaybackTime = historyPlayback.PlaybackTime;
                
                if (existingUserHistoryPlayback.PlaybackDate != historyPlayback.PlaybackDate)
                    existingUserHistoryPlayback.PlaybackDate = historyPlayback.PlaybackDate;

                bool success = Repository.UpdateHistoryPlayback(existingUserHistoryPlayback);
                if (success)
                {
                    await UnitOfWork.SaveChanges();
                    await OutputPort.Handle(
                        new HistoryPlaybacksDTO
                        {
                            IdHistory = existingUserHistoryPlayback.HistoryPlaybackId,
                            IdUser = existingUserHistoryPlayback.UserId,
                            IdContent = existingUserHistoryPlayback.ContentId,
                            PlaybackTime = existingUserHistoryPlayback.PlaybackTime,
                            PlaybackDate = existingUserHistoryPlayback.PlaybackDate
                        });
                }

            }
        }
    }
}

using DTOs.HistoryPlaybackDTO;
using Entities.Interface;
using Entities.Poco;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;

namespace UseCases.HystoryPlaybackUC
{
    public class DeletehistoryPlayblackInteractor : IDeleteHistoryPlaybackInputPort
    {
        readonly IHistoryPlaybackRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteHistoryPlaybackOutputPort OutputPort;

        public DeletehistoryPlayblackInteractor(IHistoryPlaybackRepository repository, 
                       IUnitOfWork unitOfWork, IDeleteHistoryPlaybackOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = 
            (repository, unitOfWork, outputPort);

        public async Task Handle(int IdHistoryPlayback)
        {
            HistoryPlayback NewHistoryPlayback = new()
            {
                HistoryPlaybackId = IdHistoryPlayback
            };
            var result = Repository.DeleteHistoryPlayback(NewHistoryPlayback.HistoryPlaybackId);
            await UnitOfWork.SaveChanges();
            if (result != null)
            {
                await OutputPort.Handle(
                    new HistoryPlaybacksDTO
                    {
                        IdHistory = result.HistoryPlaybackId,
                        IdUser = result.UserId,
                        IdContent = result.ContentId,
                        PlaybackTime = result.PlaybackTime,
                        PlaybackDate = result.PlaybackDate
                    }
                );
            }
        }
    }
}

using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class HistoryPlaybackRepository : IHistoryPlaybackRepository
    {
        readonly SpiderWatcherContext Context;
        public HistoryPlaybackRepository(SpiderWatcherContext context) 
            => Context = context;

        public void CreateHistoryPlayback(HistoryPlayback historyPlayback) => 
            Context.Add(historyPlayback);
        public void DeleteHistoryPlayback(int id) => 
            Context.Remove(ReadHistoryPlayback(id));
        public IEnumerable<HistoryPlayback> ReadAllHistoryPlaybacks() => 
            Context.HistoryPlaybacks ?? null;
        public HistoryPlayback ReadHistoryPlayback(int id) => 
            Context.HistoryPlaybacks.FirstOrDefault(h => h.HistoryPlaybackId == id) ?? null;
        public bool UpdateHistoryPlayback(HistoryPlayback historyPlayback) => 
            Context.HistoryPlaybacks.Update(historyPlayback) != null;
    }
}

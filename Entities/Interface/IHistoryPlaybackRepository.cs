using Entities.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IHistoryPlaybackRepository
    {
        Task CreateHistoryPlaybackAsync(HistoryPlayback historyPlayback);
        Task<HistoryPlayback> ReadHistoryPlaybackAsync(int id);
        Task UpdateHistoryPlaybackAsync(HistoryPlayback historyPlayback);
        Task DeleteHistoryPlaybackAsync(int id);

        Task<IEnumerable<HistoryPlayback>> ReadAllHistoryPlaybacksAsync();
    }
}

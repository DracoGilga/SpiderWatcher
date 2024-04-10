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
        void CreateHistoryPlayback(HistoryPlayback historyPlayback);
        HistoryPlayback ReadHistoryPlayback(int id);
        bool UpdateHistoryPlayback(HistoryPlayback historyPlayback);
        HistoryPlayback DeleteHistoryPlayback(int id);

        IEnumerable<HistoryPlayback> ReadAllHistoryPlaybacks();
    }
}

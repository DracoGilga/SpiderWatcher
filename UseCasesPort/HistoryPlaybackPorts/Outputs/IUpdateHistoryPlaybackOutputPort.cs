using DTOs.HistoryPlaybackDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPort.HistoryPlaybackPorts.Outputs
{
    public interface IUpdateHistoryPlaybackOutputPort
    {
        Task Handle(UpdateHistoryPlaybackDTO historyPlayback);
    }
}

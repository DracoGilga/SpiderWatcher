using DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.User
{
    public class UpgradeUserPresenter :
        IUpgradeUserOutputPort, IPresenter<UpgradeUserDTO>
    {
        public UpgradeUserDTO Content { get; private set;}

        public Task Handle(UpgradeUserDTO user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}

using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UserController
{
    [Route("[Controller]")]
    [ApiController]
    public class UpgradeUserController
    {
        readonly IUpgradeUserInputPort InputPort;
        readonly IUpgradeUserOutputPort OutputPort;

        public UpgradeUserController(IUpgradeUserInputPort inputPort,
                                  IUpgradeUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpgradeUserDTO> UpgradeUser(UpgradeUserDTO userDTO)
        {
            await InputPort.Handle(userDTO);
            return ((UpgradeUserPresenter)OutputPort).Content;
        }
    }
}

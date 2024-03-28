using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("api/[Controller]")]
    public class ReadUserController
    {
        readonly IReadUserInputPort InputPort;
        readonly IReadUserOutputPort OutputPort;

        public ReadUserController(IReadUserInputPort inputPort,
                                  IReadUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("{IdUser}")]
        public async Task<ReadUserDTO> ReadUser(int IdUser)
        {
            await InputPort.Handle(IdUser);
            return ((ReadUserPresenter)OutputPort).Content;
        }
    }
}

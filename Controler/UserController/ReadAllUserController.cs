using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("[Controller]")]
    [ApiController]
    public class ReadAllUserController
    {
        readonly IReadAllUsersInputPort InputPort;
        readonly IReadAllUsersOutputPort OutputPort;

        public ReadAllUserController(IReadAllUsersInputPort inputPort,
                       IReadAllUsersOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IEnumerable<UsersDTO>> ReadAllUsers()
        {
            await InputPort.Handle();
            return ((ReadAllUsersPresenter)OutputPort).Content;
        }
    }
}

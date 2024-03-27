using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("api / [Controller]")]
    [ApiController]
    public class ReadAllUserController
    {
        readonly IReadAllUsersInputPort InputPort;
        readonly IReadAllUsersOutputPort OutputPort;

        public ReadAllUserController(IReadAllUsersInputPort inputPort,
                       IReadAllUsersOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<UsersDTO> ReadAllUsers()
        {
            await InputPort.Handle();
            return ((IPresenter<UsersDTO>)OutputPort).Content;
        }
    }
}

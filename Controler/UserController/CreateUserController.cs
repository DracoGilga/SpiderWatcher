using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CreateUserController
    {
        readonly ICreateUserInputPort InputPort;
        readonly ICreateUserOutputPort OutputPort;

        public CreateUserController(ICreateUserInputPort inputPort, 
            ICreateUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CreateUserDTO> CreateUser(CreateUserDTO userDTO)
        {
            await InputPort.Handle(userDTO);
            return ((CreateUserPresenter)OutputPort).Content;
        }
    }
}

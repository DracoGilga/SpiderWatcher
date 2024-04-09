using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UpdateUserController
    {
        readonly IUpdateUserInputPort InputPort;
        readonly IUpdateUserOutputPort OutputPort;

        public UpdateUserController(IUpdateUserInputPort inputPort,
                       IUpdateUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdateUserDTO> UpdateUser(UpdateUserDTO userDTO)
        {
            await InputPort.Handle(userDTO);
            return ((UpdateUserPresenter)OutputPort).Content;
        }
    }
}

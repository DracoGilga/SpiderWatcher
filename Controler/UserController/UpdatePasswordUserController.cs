using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UpdatePasswordUserController
    {
        readonly IUpdatePasswordUserInputPort InputPort;
        readonly IUpdatePasswordUserOutputPort OutputPort;

        public UpdatePasswordUserController(IUpdatePasswordUserInputPort inputPort, 
                       IUpdatePasswordUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<UpdatePasswordUserDTO> UpdatePasswordUser(UpdatePasswordUserDTO userDTO)
        {
            await InputPort.Handle(userDTO);
            return ((UpdatePasswordUserPresenter)OutputPort).Content;
        }
    }
}

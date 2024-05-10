using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UserController
{
    [Route("[Controller]")]
    [ApiController]
    public class LoginUserController
    {
        readonly ILoginUserInputPort InputPort;
        readonly ILoginUserOutputPort OutputPort;

        public LoginUserController(ILoginUserInputPort inputPort,
                                  ILoginUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<LoginUserDTO> Handle(LoginUserDTO loginUserDTO)
        {
            await InputPort.Handle(loginUserDTO);
            return ((LoginUserPresenter)OutputPort).Content;
        }
    }
}

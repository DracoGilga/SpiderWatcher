using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Presenters.User;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UserController
{
    [Route("[Controller]")]
    [ApiController]
    public class DeleteUserController
    {
        readonly IDeleteUserInputPort InputPort;
        readonly IDeleteUserOutputPort OutputPort;

        public DeleteUserController(IDeleteUserInputPort inputPort, 
                       IDeleteUserOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("{IdUser}")]
        public async Task<UsersDTO> DeleteUser(int IdUser)
        {
            await InputPort.Handle(IdUser);
            return ((DeleteUserPresenter)OutputPort).Content;
        }
    }
}

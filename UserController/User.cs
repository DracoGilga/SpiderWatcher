using DTOs;
using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Presenters.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace UserController
{
    [Route("[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly ICreateUserInputPort CreateUserInputPort;
        private readonly ICreateUserOutputPort CreateUserOutputPort;
        private readonly IDeleteUserInputPort DeleteUserInputPort;
        private readonly IDeleteUserOutputPort DeleteUserOutputPort;
        private readonly ILoginUserInputPort LoginUserInputPort;
        private readonly ILoginUserOutputPort LoginUserOutputPort;
        private readonly IReadAllUsersInputPort ReadAllUsersInputPort;
        private readonly IReadAllUsersOutputPort ReadAllUsersOutputPort;
        private readonly IReadUserInputPort ReadUserInputPort;
        private readonly IReadUserOutputPort ReadUserOutputPort;
        private readonly IUpdatePasswordUserInputPort UpdatePasswordUserInputPort;
        private readonly IUpdatePasswordUserOutputPort UpdatePasswordUserOutputPort;
        private readonly IUpdateUserInputPort UpdateUserInputPort;
        private readonly IUpdateUserOutputPort UpdateUserOutputPort;
        private readonly IUpgradeUserInputPort UpgradeUserInputPort;
        private readonly IUpgradeUserOutputPort UpgradeUserOutputPort;
        private readonly IRecoverPasswordInputPort RecoverPasswordInputPort;
        private readonly IRecoverPasswordOutputPort RecoverPasswordOutputPort;
        private readonly JWTSettings JwtSettings;

        public User(
            ICreateUserInputPort createUserInputPort,
            ICreateUserOutputPort createUserOutputPort,
            IDeleteUserInputPort deleteUserInputPort,
            IDeleteUserOutputPort deleteUserOutputPort,
            ILoginUserInputPort loginUserInputPort,
            ILoginUserOutputPort loginUserOutputPort,
            IReadAllUsersInputPort readAllUsersInputPort,
            IReadAllUsersOutputPort readAllUsersOutputPort,
            IReadUserInputPort readUserInputPort,
            IReadUserOutputPort readUserOutputPort,
            IUpdatePasswordUserInputPort updatePasswordUserInputPort,
            IUpdatePasswordUserOutputPort updatePasswordUserOutputPort,
            IUpdateUserInputPort updateUserInputPort,
            IUpdateUserOutputPort updateUserOutputPort,
            IUpgradeUserInputPort upgradeUserInputPort,
            IUpgradeUserOutputPort upgradeUserOutputPort,
            IRecoverPasswordInputPort recoverPasswordInputPort,
            IRecoverPasswordOutputPort recoverPasswordOutputPort,
            JWTSettings jwtSettings)
        {
            CreateUserInputPort = createUserInputPort;
            CreateUserOutputPort = createUserOutputPort;
            DeleteUserInputPort = deleteUserInputPort;
            DeleteUserOutputPort = deleteUserOutputPort;
            LoginUserInputPort = loginUserInputPort;
            LoginUserOutputPort = loginUserOutputPort;
            ReadAllUsersInputPort = readAllUsersInputPort;
            ReadAllUsersOutputPort = readAllUsersOutputPort;
            ReadUserInputPort = readUserInputPort;
            ReadUserOutputPort = readUserOutputPort;
            UpdatePasswordUserInputPort = updatePasswordUserInputPort;
            UpdatePasswordUserOutputPort = updatePasswordUserOutputPort;
            UpdateUserInputPort = updateUserInputPort;
            UpdateUserOutputPort = updateUserOutputPort;
            UpgradeUserInputPort = upgradeUserInputPort;
            UpgradeUserOutputPort = upgradeUserOutputPort;
            RecoverPasswordInputPort = recoverPasswordInputPort;
            RecoverPasswordOutputPort = recoverPasswordOutputPort;
            JwtSettings = jwtSettings;
        }

        [HttpPost]
        public async Task<CreateUserSuccessDTO> Create(CreateUserDTO userDTO)
        {
            await CreateUserInputPort.Handle(userDTO);
            return ((CreateUserPresenter)CreateUserOutputPort).Content;
        }

        [HttpDelete("{idUser}")]
        public async Task<UsersDTO> Delete(int idUser)
        {
            await DeleteUserInputPort.Handle(idUser);
            return ((DeleteUserPresenter)DeleteUserOutputPort).Content;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            await LoginUserInputPort.Handle(loginUserDTO);
            var user = ((LoginUserPresenter)LoginUserOutputPort).Content;

            if (user == null)
                return Unauthorized();

            var token = GenerateJwtToken(user);
            return Ok(new { user, token });
        }

        [HttpGet]
        public async Task<IEnumerable<UsersDTO>> ReadAll()
        {
            await ReadAllUsersInputPort.Handle();
            return ((ReadAllUsersPresenter)ReadAllUsersOutputPort).Content;
        }

        [HttpGet("{idUser}")]
        public async Task<ReadUserDTO> Read(int idUser)
        {
            await ReadUserInputPort.Handle(idUser);
            return ((ReadUserPresenter)ReadUserOutputPort).Content;
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserContainerDTO userDTO)
        {
            switch (userDTO.UpdateType)
            {
                case "UpdatePassword":
                    var updatePasswordDTO = new UpdatePasswordUserDTO
                    {

                        Password = userDTO.Password,
                        ValidationMessage = userDTO.ValidationMessage,
                        Email = userDTO.UserEmail
                    };
                    await UpdatePasswordUserInputPort.Handle(updatePasswordDTO);
                    return Ok(((UpdatePasswordUserPresenter)UpdatePasswordUserOutputPort).Content);

                case "UpdateUser":
                    var updateUserDTO = new UpdateUserDTO
                    {
                        IdUser = userDTO.IdUser,
                        ValidationMessage = userDTO.ValidationMessage
                    };
                    await UpdateUserInputPort.Handle(updateUserDTO);
                    return Ok(((UpdateUserPresenter)UpdateUserOutputPort).Content);

                case "UpgradeUser":
                    var upgradeUserDTO = new UpgradeUserDTO
                    {
                        IdUser = userDTO.IdUser,
                        UserName = userDTO.UserName,
                        AccountType = userDTO.AccountType ?? false
                    };
                    await UpgradeUserInputPort.Handle(upgradeUserDTO);
                    return Ok(((UpgradeUserPresenter)UpgradeUserOutputPort).Content);

                default:
                    return BadRequest("Invalid UpdateType");
            }
        }

        [HttpPost("Recover")]
        public async Task<RecoverPasswordDTO> Recover(RecoverPasswordDTO recover)
        {
            await RecoverPasswordInputPort.Handle(recover);
            return ((RecoverPasswordPresenter)RecoverPasswordOutputPort).Content;
        }

        private string GenerateJwtToken(ResultLoginUserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Key);

            var claims = new List<Claim>
            {
                new Claim("AccountType", user.AccountType.ToString()),
                new Claim("scope", "SpiderWatcherJWT")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(JwtSettings.Duration),
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
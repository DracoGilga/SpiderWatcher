﻿using DTOs;
using DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Presenters.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UseCasesPort.UserPort.Inputs;
using UseCasesPort.UserPort.Outputs;

namespace Controler.UserController
{
    [Route("[Controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly ILoginUserInputPort InputPort;
        private readonly ILoginUserOutputPort OutputPort;
        private readonly JWTSettings JwtSettings;

        public LoginUserController(ILoginUserInputPort inputPort,
                ILoginUserOutputPort outputPort,
                JWTSettings jwtSettings) =>
            (InputPort, OutputPort, JwtSettings) =
            (inputPort, outputPort, jwtSettings);


        [HttpPost]
        public async Task<IActionResult> Handle(LoginUserDTO loginUserDTO)
        {
            await InputPort.Handle(loginUserDTO);
            var user = ((LoginUserPresenter)OutputPort).Content;

            if (user == null)
                return Unauthorized();

            var token = GenerateJwtToken(user);
            return Ok(new { user, token });
        }

        private string GenerateJwtToken(ResultLoginUserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("AccountType", user.AccountType.ToString())
                }),
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
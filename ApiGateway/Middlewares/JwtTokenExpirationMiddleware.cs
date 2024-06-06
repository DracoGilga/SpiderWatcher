using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DTOs;

namespace ApiGateway.Middlewares;
public class JwtTokenExpirationMiddleware
{
    private readonly RequestDelegate Next;
    private readonly IConfiguration Configuration;

    public JwtTokenExpirationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        Next = next;
        Configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var jwtSettings = Configuration.GetSection("JWTSettings").Get<JWTSettings>();
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                var expClaim = principal.FindFirst(JwtRegisteredClaimNames.Exp);
                var exp = long.Parse(expClaim.Value);

                var tokenExpiryDate = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;
                if (tokenExpiryDate <= DateTime.UtcNow)
                {
                    var newToken = GenerateJwtToken(principal.Claims, jwtSettings);
                    context.Response.Headers.Add("Refreshed-Token", newToken);
                }
            }
            catch (SecurityTokenExpiredException)
            {
                var newToken = GenerateJwtToken(context.User.Claims, jwtSettings);
                context.Response.Headers.Add("Refreshed-Token", newToken);
            }
            catch
            {
                // token is invalid, proceed to the next middleware
            }
        }

        await Next(context);
    }

    private string GenerateJwtToken(IEnumerable<Claim> claims, JWTSettings jwtSettings)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(jwtSettings.Duration),
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

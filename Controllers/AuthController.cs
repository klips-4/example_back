using Microsoft.AspNetCore.Authentication;
using example_back.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Npgsql;
using Newtonsoft.Json;

namespace example_back.Controllers
{
    [Route("/api/auth/sign_in")]

    public class Auth : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {

            string login = user.UserName;
            string password = user.Password;

            if (login == "1234" && password == "56789")
            {
                var claims = new List<Claim>
                {
		
                };

                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.Now.Add(TimeSpan.FromSeconds(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);

                return Ok(new { accessToken = jwtToken });
            }
            else
            {
                return Unauthorized("Неверные имя пользователя или пароль.");
            }
        }
    }
}
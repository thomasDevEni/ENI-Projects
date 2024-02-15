
using Application.Dto;
using SortieWebApp.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]

    public class LoginController : ControllerBase
    {
        // Dummy list of users (replace this with your actual user database)
        private static readonly List<UserDto> _users = new List<UserDto>
    {
        new UserDto { UserName = "admin", Password = "Pa$$w0rd" }
    };
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Post(LoginModel loginRequest)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }

        /*[HttpPost("login")]
        public IActionResult Login( LoginModel model)
        {
            // Authenticate user (validate credentials) and generate a JWT token
            if (UserAuthenticated(model.Username, model.Password))
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private bool UserAuthenticated(string username, string password)
        {
            // Find the user with the provided username
            var user = _users.FirstOrDefault(u => u.UserName == username);

            // If no user found or password doesn't match, return false
            if (user == null || user.Password != password)
            {
                return false;
            }

            return true;
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyForAuthenticationOfApplication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("MySortieApp.com", "UneBandeDeNazes", new[]
            {
                new Claim(ClaimTypes.Name, username)
            },
                expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
    }
}

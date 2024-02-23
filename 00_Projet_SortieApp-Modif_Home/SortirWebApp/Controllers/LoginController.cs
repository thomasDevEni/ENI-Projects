
using Application.Dto;
using Application.Services;
using SortieWebApp.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]

    public class LoginController : ControllerBase
    {
        // Dummy list of users (replace this with your actual user database)
        private static readonly List<LoginDto> _users = new List<LoginDto>
    {
        new LoginDto { UserName = "admin", Password = "Pa$$w0rd" }
    };
        private ILoginService _loginService;
       
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /*[HttpPost]
        public IActionResult Login(LoginModel loginRequest)
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
        }*/

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Validate the username and password
            if (!await AuthenticateUser(model.Username, model.Password))
            {
                return Unauthorized();
            }

            // If valid, generate a JWT token
            var token = GenerateJwtToken(model.Username);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //Hash the Password During User Registration
        public static string HashPassword(string password)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Hash the password
            return hasher.HashPassword(null, password);
        }

        public static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Verify the password
            var result = hasher.VerifyHashedPassword(null, hashedPassword, plainTextPassword);

            // Result will be PasswordVerificationResult.Success if the password matches
            return result == PasswordVerificationResult.Success;
        }

        [HttpPost("register")]
        public async Task RegisterUser(string username, string password)
        {
            // Hash the password
            string hashedPassword = HashPassword(password);
            _password = hashedPassword;
            _username= username;


            // Store the hashed password in your database along with other user details
            // Your database logic here...
            
        }

        //Verify Hashed Password During Authentication
        [HttpGet("authenticate")]
        public async Task<bool> AuthenticateUser(string username, string password)
        {
            // Retrieve the hashed password from your database based on the username
            string hashedPasswordFromDatabase = GetHashedPasswordFromDatabase(username);

            // Verify the password
            bool isValidPassword = VerifyPassword(password, hashedPasswordFromDatabase);

            return isValidPassword;
        }

        private string GetHashedPasswordFromDatabase(string username)
        {
            return _password;
        }

       
    }
}

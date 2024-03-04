
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
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        private IJwtService _jwtService;
        private readonly IValidator<LoginDto> _loginValidator;

        public LoginController(ILoginService loginService, IValidator<LoginDto> loginValidator, IJwtService jwtService)
        {
            _loginService = loginService;
            _loginValidator = loginValidator;
            _jwtService = jwtService;
        }

        
        // POST: api/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            // Validate the username and password
            if (!await _loginService.AuthenticateLoginAsync(loginDto))
            {
                return Unauthorized();
            }

            // If valid, generate a JWT token
            string username = loginDto.Username;
            var token = _jwtService.GenerateJwtToken(username);

            return Ok(new { Token = token });
        }

        [AllowAnonymous] // Allow anonymous access to register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> RegisterLoginAsync(LoginDto userDto)
        {
            try
            {
                var result = _loginService.ValidateUser(userDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _loginService.AddUserAsync(userDto);
                return Ok(new { Message = "Utilisateur enregistré avec succès !" });
                //return CreatedAtAction(nameof(GetParticipant), new { id = participantDto.Id }, participantDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}

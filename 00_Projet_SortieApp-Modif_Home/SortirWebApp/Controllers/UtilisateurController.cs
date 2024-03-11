using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace SortieWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //[ApiController]
    public class UtilisateurController : ControllerBase
    {
        public IUtilisateurService _utilisateurService { get; set; }
        private readonly IValidator<UtilisateurDto> _utilisateurValidator;

        public UtilisateurController(IUtilisateurService utilisateurService, IValidator<UtilisateurDto> utilisateurValidator)
        {
            _utilisateurService = utilisateurService;
            _utilisateurValidator = utilisateurValidator;
        }

        // GET: api/Product
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UtilisateurDto>>> GetUtilisateurs()
        {
            var utilisateur = await _utilisateurService.GetAllUtilisateurAsync();
            return Ok(utilisateur);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilisateurDto>> GetUtilisateur(int id)
        {
            var utilisateur = await _utilisateurService.GetUtilisateurByIdAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        
        // PUT: api/Utilisateur/5
        [HttpPut("UpdateUtilisateur")]
        public async Task<IActionResult> UpdateUtilisateur(UtilisateurDto utilisateurDto)
        {
            if (utilisateurDto?.Id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _utilisateurService.UpdateUtilisateurAsync(utilisateurDto);
            }
            catch (Exception)
            {
                if (true)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Utilisateur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _utilisateurService.GetUtilisateurByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            await _utilisateurService.DeleteUtilisateurAsync(id);

            return NoContent();
        }
    }
}

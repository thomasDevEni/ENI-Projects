using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace SortieWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private readonly IInscriptionService _inscriptionService;
        private readonly IValidator<InscriptionDto> _inscriptionValidator;

        public InscriptionController(IInscriptionService inscriptionService, IValidator<InscriptionDto> inscriptionValidator)
        {
            _inscriptionService = inscriptionService;
            _inscriptionValidator = inscriptionValidator;
        }

        // GET: api/All
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<InscriptionDto>>> GetInscriptions()
        {
            var inscription = await _inscriptionService.GetAllInscriptionAsync();
            return Ok(inscription);
        }

        // GET: api/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InscriptionDto>> GetInscription(int id)
        {
            var inscription = await _inscriptionService.GetInscriptionByIdAsync(id);

            if (inscription == null)
            {
                return NotFound();
            }

            return inscription;
        }

        // POST: api/InscriptionloginDto
        [HttpPost("AddInscription")]
        public async Task<IActionResult> AddInscriptionAsync(InscriptionDto inscriptionDto)
        {
            try
            {
                var result = _inscriptionService.ValidateInscription(inscriptionDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _inscriptionService.AddInscriptionAsync(inscriptionDto);
                return Ok();
                //return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT: api/Inscription/5
        [HttpPut("UpdateInscription")]
        public async Task<IActionResult> UpdateInscription(InscriptionDto inscriptionDto)
        {
            if (inscriptionDto?.Id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _inscriptionService.UpdateInscriptionAsync(inscriptionDto);
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

        
        // DELETE: api/Inscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            var inscription = await _inscriptionService.GetInscriptionByIdAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }

            await _inscriptionService.DeleteInscriptionAsync(id);

            return NoContent();
        }
    }
}

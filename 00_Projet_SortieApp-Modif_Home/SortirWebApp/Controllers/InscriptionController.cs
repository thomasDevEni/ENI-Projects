using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class InscriptionController : ControllerBase
    {
        private readonly IInscriptionService _inscriptionService;
        private readonly IValidator<InscriptionDto> _inscriptionValidator;

        public InscriptionController(IInscriptionService inscriptionService, IValidator<InscriptionDto> inscriptionValidator)
        {
            _inscriptionService = inscriptionService;
            _inscriptionValidator = inscriptionValidator;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscriptionDto>>> GetInscriptions()
        {
            var inscription = await _inscriptionService.GetAllInscriptionAsync();
            return Ok(inscription);
        }

        // GET: api/Product/5
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

        // POST: api/Inscription
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInscription(int id, InscriptionDto inscriptionDto)
        {
            if (id != inscriptionDto.Id)
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

        [HttpGet("Exists/{id}")]
        public async Task<bool> InscriptionExists(int id)
        {
            // Assume _inscriptionService.GetInscriptionByIdAsync(id) exists and retrieves the Inscription entity by its id
            var inscription = await _inscriptionService.GetInscriptionByIdAsync(id);
            // Return true if the inscription is not null, indicating that the entity with the specified ID exists
            // Otherwise, return false

            return (inscription != null);
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

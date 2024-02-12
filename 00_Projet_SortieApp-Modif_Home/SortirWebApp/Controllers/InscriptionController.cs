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
    }
}

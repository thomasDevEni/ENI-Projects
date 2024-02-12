using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class InscriptionController : ControllerBase
    {
        private readonly IInscriptionService _inscriptionService;
        public InscriptionController(IInscriptionService inscriptionService)
        {
            _inscriptionService = inscriptionService;
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
        [HttpPost]
        public async Task<IActionResult> AddInscriptionAsync(InscriptionDto inscriptionDto)
        {
            try
            {
                await _inscriptionService.AddInscriptionAsync(inscriptionDto);
                return Ok(_inscriptionService);
                //return CreatedAtAction(nameof(GetInscription), new { id = inscriptionDto.Id }, inscriptionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

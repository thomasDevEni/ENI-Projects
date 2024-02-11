using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class EtatController : ControllerBase
    {
        private readonly IEtatService _etatService;
        public EtatController(IEtatService etatService) 
        {
        _etatService = etatService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatDto>>> GetProducts()
        {
            var etat = await _etatService.GetAllEtatAsync();
            return Ok(etat);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatDto>> GetEtat(int id)
        {
            var product = await _etatService.GetEtatByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Etat
        [HttpPost]
        public async Task<IActionResult> AddEtatAsync(EtatDto etatDto)
        {
            try
            {
                await _etatService.AddEtatAsync(etatDto);
                return CreatedAtAction(nameof(GetEtat), new { id = etatDto.Id }, etatDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

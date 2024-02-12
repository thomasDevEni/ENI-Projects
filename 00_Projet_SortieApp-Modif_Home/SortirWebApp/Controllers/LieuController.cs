using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class LieuController : ControllerBase
    {
        private readonly ILieuService _lieuService;
        public LieuController(ILieuService lieuService)
        {
            _lieuService = lieuService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LieuDto>>> GetLieus()
        {
            var lieu = await _lieuService.GetAllLieuAsync();
            return Ok(lieu);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LieuDto>> GetLieu(int id)
        {
            var lieu = await _lieuService.GetLieuByIdAsync(id);

            if (lieu == null)
            {
                return NotFound();
            }

            return lieu;
        }

        // POST: api/Lieu
        [HttpPost]
        public async Task<IActionResult> AddLieuAsync(LieuDto lieuDto)
        {
            try
            {
                await _lieuService.AddLieuAsync(lieuDto);
                return Ok(_lieuService);
                //return CreatedAtAction(nameof(GetLieu), new { id = lieuDto.Id }, lieuDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class LieuController : ControllerBase
    {
        private readonly ILieuService _lieuService;
        private readonly IValidator<LieuDto> _lieuValidator;

        public LieuController(ILieuService lieuService, IValidator<LieuDto> lieuValidator)
        {
            _lieuService = lieuService;
            _lieuValidator = lieuValidator;
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
        [HttpPost("AddLieu")]
        public async Task<IActionResult> AddLieuAsync(LieuDto lieuDto)
        {
            try
            {
                var result = _lieuService.ValidateLieu(lieuDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _lieuService.AddLieuAsync(lieuDto);
                return Ok();
                //return CreatedAtAction(nameof(GetLieu), new { id = LieuDto.Id }, LieuDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

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

        // PUT: api/Lieu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLieu(int id, LieuDto lieuDto)
        {
            if (id != lieuDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _lieuService.UpdateLieuAsync(lieuDto);
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
        public async Task<bool> LieuExists(int id)
        {
            // Assume _lieuService.GetLieuByIdAsync(id) exists and retrieves the Lieu entity by its id
            var lieu = await _lieuService.GetByIdAsync(id);
            // Return true if the lieu is not null, indicating that the entity with the specified ID exists
            // Otherwise, return false

            return (lieu != null);
        }

        // DELETE: api/Lieu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLieu(int id)
        {
            var lieu = await _lieuService.GetLieuByIdAsync(id);
            if (lieu == null)
            {
                return NotFound();
            }

            await _lieuService.DeleteLieuAsync(id);

            return NoContent();
        }
    }
}

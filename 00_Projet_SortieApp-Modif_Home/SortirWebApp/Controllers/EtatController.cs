using Application.Dto;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SortieWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EtatController : ControllerBase
    {
        private readonly IEtatService _etatService;
        private readonly IValidator<EtatDto> _etatValidator;

        public EtatController(IEtatService etatService, IValidator<EtatDto> etatValidator) 
        {
        _etatService = etatService;
        _etatValidator = etatValidator;
        }
        
        // GET: api/Product
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<EtatDto>>> GetEtats()
        {
            var etat = await _etatService.GetAllEtatAsync();
            return Ok(etat);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatDto>> GetEtat(int id)
        {
            var etat = await _etatService.GetEtatByIdAsync(id);

            if (etat == null)
            {
                return NotFound();
            }

            return etat;
        }

        // POST: api/Etat
        [HttpPost("AddEtat")]
        public async Task<IActionResult> AddEtatAsync(EtatDto etatDto)
        {
            try
            {
                var result = _etatService.ValidateEtat(etatDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _etatService.AddEtatAsync(etatDto);
                return Ok();
                //return CreatedAtAction(nameof(GetEtat), new { id = etatDto.Id }, etatDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Etat/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEtat(EtatDto? etatDto)
        {
            if (etatDto?.Id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _etatService.UpdateEtatAsync(etatDto);
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

        
        // DELETE: api/Etat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtat(int id)
        {
            var etat = await _etatService.GetEtatByIdAsync(id);
            if (etat == null)
            {
                return NotFound();
            }

            await _etatService.DeleteEtatAsync(id);

            return NoContent();
        }
    }
}

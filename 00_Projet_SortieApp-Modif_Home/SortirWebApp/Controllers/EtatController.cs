using Application.Dto;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
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
                //return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

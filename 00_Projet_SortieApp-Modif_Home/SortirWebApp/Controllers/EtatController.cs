﻿using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using Domain.Entities;

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
        [HttpPost]
        public async Task<IActionResult> AddEtatAsync(EtatDto etatDto)
        {
            try
            {
                await _etatService.AddEtatAsync(etatDto);
                return Ok(_etatService);
                //return CreatedAtAction(nameof(GetEtat), new { id = etatDto.Id }, etatDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

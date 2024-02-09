using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class EtatController : ControllerBase
    {
        public EtatService _etatService { get; set; }
        public EtatController(EtatService etatService) 
        {
        _etatService = etatService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEtat(EtatDto etat)
        {
            try
            {
                _etatService.AddEtat(etat);
                return Ok(etat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

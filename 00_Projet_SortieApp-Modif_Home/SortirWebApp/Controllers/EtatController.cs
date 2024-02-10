using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class EtatController : ControllerBase
    {
        public IEtatService _etatService { get; set; }
        public EtatController(IEtatService etatService) 
        {
        _etatService = etatService;
        }

        [HttpPost]
        public IActionResult AddEtat(EtatDto etat)
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

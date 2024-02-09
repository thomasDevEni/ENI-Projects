using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class InscriptionController : ControllerBase
    {
        public InscriptionService _inscriptionService { get; set; }
        public InscriptionController(InscriptionService inscriptionService) 
        {
        _inscriptionService = inscriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInscription(InscriptionDto inscription)
        {
            try
            {
                _inscriptionService.AddInscription(inscription);
                return Ok(inscription);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

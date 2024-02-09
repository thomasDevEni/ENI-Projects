using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class LieuController : ControllerBase
    {
        public LieuService _lieuService { get; set; }
        public LieuController(LieuService lieuService) 
        {
        _lieuService = lieuService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLieu(Lieu lieu)
        {
            try
            {
                _lieuService.AddLieu(lieu);
                return Ok(lieu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

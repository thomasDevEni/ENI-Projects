using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

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
        public async Task<IActionResult> AddLieu(LieuDto lieu)
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

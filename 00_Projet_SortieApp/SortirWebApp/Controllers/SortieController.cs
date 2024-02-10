using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;


namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SortieController : ControllerBase
    {
        public SortieService _sortieService { get; set; }
        public SortieController(SortieService sortieService) 
        {
        _sortieService = sortieService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSortie(SortieDto sortie)
        {
            try
            {
                _sortieService.AddSortie(sortie);
                return Ok(sortie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

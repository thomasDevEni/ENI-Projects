using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;


namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SortieController : ControllerBase
    {
        private readonly ISortieService _sortieService;
        public SortieController(ISortieService sortieService)
        {
            _sortieService = sortieService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SortieDto>>> GetSorties()
        {
            var sortie = await _sortieService.GetAllSortieAsync();
            return Ok(sortie);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SortieDto>> GetSortie(int id)
        {
            var sortie = await _sortieService.GetSortieByIdAsync(id);

            if (sortie == null)
            {
                return NotFound();
            }

            return sortie;
        }

        // POST: api/Sortie
        [HttpPost]
        public async Task<IActionResult> AddSortieAsync(SortieDto sortieDto)
        {
            try
            {
                await _sortieService.AddSortieAsync(sortieDto);
                return Ok(_sortieService);
                //return CreatedAtAction(nameof(GetSortie), new { id = sortieDto.Id }, sortieDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

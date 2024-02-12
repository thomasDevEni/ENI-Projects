using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        public IParticipantService _participantService { get; set; }
        public ParticipantController(IParticipantService participantService) 
        {
        _participantService = participantService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetParticipants()
        {
            var participant = await _participantService.GetAllParticipantAsync();
            return Ok(participant);
        }

        // GET: api/Participant/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantDto>> GetParticipant(int id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // POST: api/Participant
        [HttpPost]
        public async Task<IActionResult> AddParticipantAsync(ParticipantDto participantDto)
        {
            try
            {
                await _participantService.AddEtatAsync(participantDto);
                
                return CreatedAtAction(nameof(GetParticipant), new { id = participantDto.Id }, participantDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

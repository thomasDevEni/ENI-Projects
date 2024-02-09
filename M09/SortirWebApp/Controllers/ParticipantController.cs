using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        public ParticipantService _participantService { get; set; }
        public ParticipantController(ParticipantService participantService) 
        {
        _participantService = participantService;
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipant(ParticipantDto participant)
        {
            try
            {
                _participantService.AddParticipant(participant);
                return Ok(participant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

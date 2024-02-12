using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        public IParticipantService _participantService { get; set; }
        private readonly IValidator<ParticipantDto> _participantValidator;

        public ParticipantController(IParticipantService participantService, IValidator<ParticipantDto> participantValidator)
        {
            _participantService = participantService;
            _participantValidator = participantValidator;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetParticipants()
        {
            var participant = await _participantService.GetAllParticipantAsync();
            return Ok(participant);
        }

        // GET: api/Product/5
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
        [HttpPost("AddParticipant")]
        public async Task<IActionResult> AddParticipantAsync(ParticipantDto participantDto)
        {
            try
            {
                var result = _participantService.ValidateParticipant(participantDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _participantService.AddParticipantAsync(participantDto);
                return Ok();
                //return CreatedAtAction(nameof(GetParticipant), new { id = participantDto.Id }, participantDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

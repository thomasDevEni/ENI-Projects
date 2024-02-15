using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace SortieWebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("GetAll")]
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
        [HttpPost(Name ="AddParticipant")]
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

        // PUT: api/Participant/5
        [HttpPut(Name ="UpdateParticipant")]
        public async Task<IActionResult> UpdateParticipant(ParticipantDto participantDto)
        {
            if (participantDto?.Id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _participantService.UpdateParticipantAsync(participantDto);
            }
            catch (Exception)
            {
                if (true)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Participant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            await _participantService.DeleteParticipantAsync(id);

            return NoContent();
        }
    }
}

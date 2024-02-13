using Application.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IParticipantService
    {
        Task AddParticipantAsync(ParticipantDto participantDto);
        Task<ParticipantDto> GetByIdAsync(int id);
        Task<List<ParticipantDto>> GetAllParticipantAsync();

        Task<ParticipantDto> GetParticipantByIdAsync(int id);

        ValidationResult ValidateParticipant(ParticipantDto participant);

        Task UpdateParticipantAsync(ParticipantDto participantDto);

        Task DeleteParticipantAsync(int id);
    }
}

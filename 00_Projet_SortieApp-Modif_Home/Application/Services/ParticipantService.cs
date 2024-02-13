using Application.Dto;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IParticipantRepository _rparticipantRepository;
        private readonly IValidator<ParticipantDto> _participantValidator;

        public ParticipantService(IMapper mapper, IParticipantRepository participantRepository, IValidator<ParticipantDto> participantValidator)
        {
            _mapper = mapper;
            _rparticipantRepository = participantRepository;
            _participantValidator = participantValidator;
        }

        public ValidationResult ValidateParticipant(ParticipantDto participant)
        {
            return _participantValidator.Validate(participant);
        }

        public async Task<ParticipantDto> GetByIdAsync(int id)
        {
            var participant = _rparticipantRepository.GetByIdAsync(id); ;
            if (_rparticipantRepository == null)
            {
                return null;
            }

            var participantDto = _mapper.Map<ParticipantDto>(participant);
            return participantDto;
        }

        public async Task<List<ParticipantDto>> GetAllParticipantAsync()
        {
            var participants = await _rparticipantRepository.GetAllAsync();
            return _mapper.Map<List<ParticipantDto>>(participants);
        }

        public async Task<ParticipantDto?> GetParticipantByIdAsync(int id)
        {
            var product = await _rparticipantRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<ParticipantDto>(product); }
        }

        public async Task AddParticipantAsync(ParticipantDto participantDto)
        {
            try
            {
                // Map ParticipanttDto to Participant entity
                var participantEntity = _mapper.Map<Participant>(participantDto);

                // Pass the mapped entity to the repository for addition
                await _rparticipantRepository.AddParticipantAsync(participantEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }

        public async Task UpdateParticipantAsync(ParticipantDto? participantDto)
        {

            if (participantDto != null)
            {
                var participantEntity = await _rparticipantRepository.GetByIdAsync(participantDto.Id);
                if (participantEntity == null)
                {
                    // Handle the case where the Participant entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (participantEntity != null)
                {   // Update the properties of the existing Participant entity with values from participantDto
                    participantEntity.Nom = participantDto.Nom;
                    participantEntity.Prenom = participantDto.Prenom;
                    participantEntity.Mail= participantDto.Mail;
                    participantEntity.RoleId = participantDto.RoleId;
                    // Save the changes back to the database
                    await _rparticipantRepository.UpdateParticipantAsync(participantEntity);

                }

            }
            else
            {
                // Handle the case where the Participant entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteParticipantAsync(int id)
        {
            // Retrieve the existing Participant entity from the database
            var participantToDelete = await _rparticipantRepository.GetByIdAsync(id);

            if (participantToDelete != null)
            {
                // Remove the Participant entity from the database
                await _rparticipantRepository.DeleteParticipantAsync(id);
            }
            else
            {
                // Handle the case where the Participant entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

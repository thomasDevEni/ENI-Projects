using Application.Dto;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ParticipantDto> GetParticipantByIdAsync(int id)
        {
            var product = await _rparticipantRepository.GetByIdAsync(id);
            return _mapper.Map<ParticipantDto>(product);
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
    }
}

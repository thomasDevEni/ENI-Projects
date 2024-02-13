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
    public class InscriptionService : IInscriptionService
    {
        private readonly IMapper _mapper;
        private readonly IInscriptionRepository _rinscriptionRepository;
        private readonly IValidator<InscriptionDto> _inscriptionValidator;

        public InscriptionService(IMapper mapper, IInscriptionRepository inscriptionRepository, IValidator<InscriptionDto> inscriptionValidator)
        {
            _mapper = mapper;
            _rinscriptionRepository = inscriptionRepository;
            _inscriptionValidator = inscriptionValidator;
        }

        public ValidationResult ValidateInscription(InscriptionDto inscription)
        {
            return _inscriptionValidator.Validate(inscription);
        }


        public async Task<List<InscriptionDto>> GetAllInscriptionAsync()
        {
            var inscriptions = await _rinscriptionRepository.GetAllAsync();

            if (_rinscriptionRepository == null)
            {
                return null;
            }
            return _mapper.Map<List<InscriptionDto>>(inscriptions);
        }

        public async Task<InscriptionDto> GetInscriptionByIdAsync(int id)
        {
            var product = await _rinscriptionRepository.GetByIdAsync(id);

            if (_rinscriptionRepository == null)
            {
                return null;
            }

            return _mapper.Map<InscriptionDto>(product);
        }

        public async Task AddInscriptionAsync(InscriptionDto inscriptionDto)
        {
            try
            {
                // Map InscriptiontDto to Inscription entity
                var inscriptionEntity = _mapper.Map<Inscription>(inscriptionDto);

                // Pass the mapped entity to the repository for addition
                await _rinscriptionRepository.AddInscriptionAsync(inscriptionEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }

        public async Task UpdateInscriptionAsync(InscriptionDto inscriptionDto)
        {
            // Map InscriptiontDto to Inscription entity
            var inscriptionEntity = _mapper.Map<Inscription>(inscriptionDto);
            // Retrieve the existing Inscription entity from the database
            //var existingInscription = await _rinscriptionRepository.UpdateInscriptionAsync(inscriptionEntity);

            if (inscriptionEntity != null)
            {
                // Update the properties of the existing Inscription entity with values from inscriptionDto
                inscriptionEntity.ParticipantId = inscriptionDto.ParticipantId;
                // Update other properties as necessary


                // Save the changes back to the database
                await _rinscriptionRepository.UpdateInscriptionAsync(inscriptionEntity);
            }
            else
            {
                // Handle the case where the Inscription entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteInscriptionAsync(int id)
        {
            // Retrieve the existing Inscription entity from the database
            var inscriptionToDelete = await _rinscriptionRepository.GetByIdAsync(id);

            if (inscriptionToDelete != null)
            {
                // Remove the Inscription entity from the database
                await _rinscriptionRepository.DeleteInscriptionAsync(id);
            }
            else
            {
                // Handle the case where the Inscription entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

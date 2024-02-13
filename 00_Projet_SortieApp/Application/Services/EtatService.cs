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
    public class EtatService : IEtatService
    {
        private readonly IMapper _mapper;
        private readonly IEtatRepository _retatRepository;
        private readonly IValidator<EtatDto> _etatValidator;

        public EtatService(IMapper mapper, IEtatRepository etatRepository, IValidator<EtatDto> etatValidator)
        {
            _mapper = mapper;
            _retatRepository = etatRepository;
            _etatValidator = etatValidator;
        }

        public ValidationResult ValidateEtat(EtatDto etat)
        {
            return _etatValidator.Validate(etat);
        }

        public async Task<EtatDto> GetByIdAsync(int id) 
        {
            var etat = _retatRepository.GetByIdAsync(id); ;
            if (_retatRepository == null) 
            {
                return null;
            }

            var etatDto = _mapper.Map<EtatDto>(etat);
            return etatDto;
        }

        public async Task<List<EtatDto>> GetAllEtatAsync()
        {
            var etats = await _retatRepository.GetAllAsync();
            return _mapper.Map<List<EtatDto>>(etats);
        }

        public async Task<EtatDto?> GetEtatByIdAsync(int id)
        {
            var product = await _retatRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<EtatDto>(product); }
        }

        public async Task AddEtatAsync(EtatDto etatDto)
        {
            try
            {
                // Map EtattDto to Etat entity
                var etatEntity = _mapper.Map<Etat>(etatDto);

                // Pass the mapped entity to the repository for addition
                await _retatRepository.AddEtatAsync(etatEntity);


            }
            catch (Exception ex)

            { 
                throw new Exception();
            }
        }

        public async Task  UpdateEtatAsync(EtatDto? etatDto)
        {

            if (etatDto != null)
            {
                var etatEntity = await _retatRepository.GetByIdAsync(etatDto.Id);
                if (etatEntity == null) 
                {
                    // Handle the case where the Etat entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (etatEntity != null)
                {   // Update the properties of the existing Etat entity with values from etatDto
                    etatEntity.Libelle = etatDto.Libelle;
                    // Save the changes back to the database
                    await _retatRepository.UpdateEtatAsync(etatEntity);

                }
                
            }
            else
            {
                // Handle the case where the Etat entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteEtatAsync(int id)
        {
            // Retrieve the existing Etat entity from the database
            var etatToDelete = await _retatRepository.GetByIdAsync(id);
                        
            if (etatToDelete != null)
            {
                // Remove the Etat entity from the database
                await _retatRepository.DeleteEtatAsync(id);
            }
            else
            {
                // Handle the case where the Etat entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

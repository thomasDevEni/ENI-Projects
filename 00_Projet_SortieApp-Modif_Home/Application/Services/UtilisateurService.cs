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
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IMapper _mapper;
        private readonly IUtilisateurRepository _rutilisateurRepository;
        private readonly IValidator<UtilisateurDto> _utilisateurValidator;

        public UtilisateurService(IMapper mapper, IUtilisateurRepository utilisateurRepository, IValidator<UtilisateurDto> utilisateurValidator)
        {
            _mapper = mapper;
            _rutilisateurRepository = utilisateurRepository;
            _utilisateurValidator = utilisateurValidator;
        }

        public ValidationResult ValidateUtilisateur(UtilisateurDto utilisateur)
        {
            return _utilisateurValidator.Validate(utilisateur);
        }

        public async Task<UtilisateurDto> GetByIdAsync(int id)
        {
            var utilisateur = _rutilisateurRepository.GetByIdAsync(id); ;
            if (_rutilisateurRepository == null)
            {
                return null;
            }

            var utilisateurDto = _mapper.Map<UtilisateurDto>(utilisateur);
            return utilisateurDto;
        }

        public async Task<List<UtilisateurDto>> GetAllUtilisateurAsync()
        {
            var utilisateurs = await _rutilisateurRepository.GetAllAsync();
            return _mapper.Map<List<UtilisateurDto>>(utilisateurs);
        }

        public async Task<UtilisateurDto?> GetUtilisateurByIdAsync(int id)
        {
            var product = await _rutilisateurRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<UtilisateurDto>(product); }
        }

        
        public async Task UpdateUtilisateurAsync(UtilisateurDto? utilisateurDto)
        {

            if (utilisateurDto != null)
            {
                var utilisateurEntity = await _rutilisateurRepository.GetByIdAsync(utilisateurDto.Id);
                if (utilisateurEntity == null)
                {
                    // Handle the case where the Utilisateur entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (utilisateurEntity != null)
                {   // Update the properties of the existing Utilisateur entity with values from utilisateurDto
                    utilisateurEntity.LastName = utilisateurDto.LastName;
                    utilisateurEntity.FirstName = utilisateurDto.FirstName;
                    utilisateurEntity.Mail= utilisateurDto.Mail;
                    //utilisateurEntity.RoleId = utilisateurDto.RoleId;
                    // Save the changes back to the database
                    await _rutilisateurRepository.UpdateUserAsync(utilisateurEntity);

                }

            }
            else
            {
                // Handle the case where the Utilisateur entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteUtilisateurAsync(int id)
        {
            // Retrieve the existing Utilisateur entity from the database
            var utilisateurToDelete = await _rutilisateurRepository.GetByIdAsync(id);

            if (utilisateurToDelete != null)
            {
                // Remove the Utilisateur entity from the database
                await _rutilisateurRepository.DeleteUserAsync(id);
            }
            else
            {
                // Handle the case where the Utilisateur entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

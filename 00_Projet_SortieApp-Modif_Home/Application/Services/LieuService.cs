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
    public class LieuService : ILieuService
    {
        private readonly IMapper _mapper;
        private readonly ILieuRepository _rlieuRepository;
        private readonly IValidator<LieuDto> _lieuValidator;

        public LieuService(IMapper mapper, ILieuRepository lieuRepository, IValidator<LieuDto> lieuValidator)
        {
            _mapper = mapper;
            _rlieuRepository = lieuRepository;
            _lieuValidator = lieuValidator;
        }

        public ValidationResult ValidateLieu(LieuDto lieu)
        {
            return _lieuValidator.Validate(lieu);
        }

        public async Task<LieuDto> GetByIdAsync(int id)
        {
            var lieu = _rlieuRepository.GetByIdAsync(id); ;
            if (_rlieuRepository == null)
            {
                return null;
            }

            var lieuDto = _mapper.Map<LieuDto>(lieu);
            return lieuDto;
        }

        public async Task<List<LieuDto>> GetAllLieuAsync()
        {
            var lieus = await _rlieuRepository.GetAllAsync();
            return _mapper.Map<List<LieuDto>>(lieus);
        }

        public async Task<LieuDto?> GetLieuByIdAsync(int id)
        {
            var product = await _rlieuRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<LieuDto>(product); }
        }

        public async Task AddLieuAsync(LieuDto lieuDto)
        {
            try
            {
                // Map LieutDto to Lieu entity
                var lieuEntity = _mapper.Map<Lieu>(lieuDto);

                // Pass the mapped entity to the repository for addition
                await _rlieuRepository.AddLieuAsync(lieuEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }

        public async Task UpdateLieuAsync(LieuDto? lieuDto)
        {

            if (lieuDto != null)
            {
                var lieuEntity = await _rlieuRepository.GetByIdAsync(lieuDto.Id);
                if (lieuEntity == null)
                {
                    // Handle the case where the Lieu entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (lieuEntity != null)
                {   // Update the properties of the existing Lieu entity with values from lieuDto
                    lieuEntity.Etablissement = lieuDto.Etablissement;
                    lieuEntity.Adresse = lieuDto.Adresse;
                    lieuEntity.CodePostal = lieuDto.CodePostal;
                    lieuEntity.CoordonneeGPS=lieuDto.CoordonneeGPS;
                    // Save the changes back to the database
                    await _rlieuRepository.UpdateLieuAsync(lieuEntity);

                }

            }
            else
            {
                // Handle the case where the Lieu entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteLieuAsync(int id)
        {
            // Retrieve the existing Lieu entity from the database
            var lieuToDelete = await _rlieuRepository.GetByIdAsync(id);

            if (lieuToDelete != null)
            {
                // Remove the Lieu entity from the database
                await _rlieuRepository.DeleteLieuAsync(id);
            }
            else
            {
                // Handle the case where the Lieu entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

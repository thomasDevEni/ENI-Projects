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
    public class SortieService : ISortieService
    {
        private readonly IMapper _mapper;
        private readonly ISortieRepository _rsortieRepository;
        private readonly IValidator<SortieDto> _sortieValidator;

        public SortieService(IMapper mapper, ISortieRepository sortieRepository, IValidator<SortieDto> sortieValidator)
        {
            _mapper = mapper;
            _rsortieRepository = sortieRepository;
            _sortieValidator = sortieValidator;
        }

        public ValidationResult ValidateSortie(SortieDto sortie)
        {
            return _sortieValidator.Validate(sortie);
        }

        public async Task<SortieDto> GetByIdAsync(int id)
        {
            var sortie = _rsortieRepository.GetByIdAsync(id); ;
            if (_rsortieRepository == null)
            {
                return null;
            }

            var sortieDto = _mapper.Map<SortieDto>(sortie);
            return sortieDto;
        }

        public async Task<List<SortieDto>> GetAllSortieAsync()
        {
            var sorties = await _rsortieRepository.GetAllAsync();
            return _mapper.Map<List<SortieDto>>(sorties);
        }

        public async Task<SortieDto?> GetSortieByIdAsync(int id)
        {
            var product = await _rsortieRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<SortieDto>(product); }
        }

        public async Task AddSortieAsync(SortieDto sortieDto)
        {
            try
            {
                // Map SortietDto to Sortie entity
                var sortieEntity = _mapper.Map<Sortie>(sortieDto);

                // Pass the mapped entity to the repository for addition
                await _rsortieRepository.AddSortieAsync(sortieEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }

        public async Task UpdateSortieAsync(SortieDto? sortieDto)
        {

            if (sortieDto != null)
            {
                var sortieEntity = await _rsortieRepository.GetByIdAsync(sortieDto.Id);
                if (sortieEntity == null)
                {
                    // Handle the case where the Sortie entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (sortieEntity != null)
                {   // Update the properties of the existing Sortie entity with values from sortieDto
                    sortieEntity.Nom=sortieDto.Nom;
                    sortieEntity.LieuId = sortieDto.LieuId;
                    sortieEntity.OrganisateurId= sortieDto.OrganisateurId;
                    sortieEntity.DateDebut = sortieDto.DateDebut;
                    sortieEntity.DateFin = sortieDto.DateFin;
                    sortieEntity.EtatId = sortieDto.EtatId;
                    // Save the changes back to the database
                    await _rsortieRepository.UpdateSortieAsync(sortieEntity);

                }

            }
            else
            {
                // Handle the case where the Sortie entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteSortieAsync(int id)
        {
            // Retrieve the existing Sortie entity from the database
            var sortieToDelete = await _rsortieRepository.GetByIdAsync(id);

            if (sortieToDelete != null)
            {
                // Remove the Sortie entity from the database
                await _rsortieRepository.DeleteSortieAsync(id);
            }
            else
            {
                // Handle the case where the Sortie entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

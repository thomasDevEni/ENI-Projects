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

        public async Task<LieuDto> GetLieuByIdAsync(int id)
        {
            var product = await _rlieuRepository.GetByIdAsync(id);
            return _mapper.Map<LieuDto>(product);
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
    }
}

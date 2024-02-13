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
    }
}

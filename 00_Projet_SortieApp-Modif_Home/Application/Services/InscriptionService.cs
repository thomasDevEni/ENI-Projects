using Application.Dto;
using AutoMapper;
using Domain.Entities;
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


        public InscriptionService(IMapper mapper, IInscriptionRepository inscriptionRepository)
        {
            _mapper = mapper;
            _rinscriptionRepository = inscriptionRepository;
        }

        public async Task<InscriptionDto> GetByIdAsync(int id)
        {
            var inscription = _rinscriptionRepository.GetByIdAsync(id); ;
            if (_rinscriptionRepository == null)
            {
                return null;
            }

            var inscriptionDto = _mapper.Map<InscriptionDto>(inscription);
            return inscriptionDto;
        }

        public async Task<List<InscriptionDto>> GetAllInscriptionAsync()
        {
            var inscriptions = await _rinscriptionRepository.GetAllAsync();
            return _mapper.Map<List<InscriptionDto>>(inscriptions);
        }

        public async Task<InscriptionDto> GetInscriptionByIdAsync(int id)
        {
            var inscription = await _rinscriptionRepository.GetByIdAsync(id);
            return _mapper.Map<InscriptionDto>(inscription);
        }

        public async Task AddInscriptionAsync(InscriptionDto inscriptionDto)
        {
            try
            {
                // Map EtattDto to Etat entity
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

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

namespace Application.Services
{
    public class EtatService : IEtatService
    {
        private readonly IMapper _mapper;
        private readonly IEtatRepository _retatRepository;


        public EtatService(IMapper mapper, IEtatRepository etatRepository)
        {
            _mapper = mapper;
            _retatRepository = etatRepository;
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

        public async Task<EtatDto> GetEtatByIdAsync(int id)
        {
            var product = await _retatRepository.GetByIdAsync(id);
            return _mapper.Map<EtatDto>(product);
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
    }
}

using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SortieService : ISortieService
    {
        private readonly IMapper _mapper;
        private readonly ISortieRepository _rsortieRepository;


        public SortieService(IMapper mapper, ISortieRepository sortieRepository)
        {
            _mapper = mapper;
            _rsortieRepository = sortieRepository;
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

        public async Task<SortieDto> GetSortieByIdAsync(int id)
        {
            var product = await _rsortieRepository.GetByIdAsync(id);
            return _mapper.Map<SortieDto>(product);
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
    
    }
}

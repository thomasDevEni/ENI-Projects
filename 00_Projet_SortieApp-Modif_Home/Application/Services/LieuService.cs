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
    public class LieuService : ILieuService
    {
        private readonly IMapper _mapper;
        private readonly ILieuRepository _rLieuRepository;


        public LieuService(IMapper mapper, ILieuRepository LieuRepository)
        {
            _mapper = mapper;
            _rLieuRepository = LieuRepository;
        }



        public async Task<LieuDto> GetByIdAsync(int id)
        {
            var Lieu = _rLieuRepository.GetByIdAsync(id); ;
            if (_rLieuRepository == null)
            {
                return null;
            }

            var LieuDto = _mapper.Map<LieuDto>(Lieu);
            return LieuDto;
        }

        public async Task<List<LieuDto>> GetAllLieuAsync()
        {
            var Lieus = await _rLieuRepository.GetAllAsync();
            return _mapper.Map<List<LieuDto>>(Lieus);
        }

        public async Task<LieuDto> GetLieuByIdAsync(int id)
        {
            var lieu = await _rLieuRepository.GetByIdAsync(id);
            return _mapper.Map<LieuDto>(lieu);
        }

        public async Task AddLieuAsync(LieuDto LieuDto)
        {
            try
            {
                // Map LieutDto to Lieu entity
                var LieuEntity = _mapper.Map<Lieu>(LieuDto);

                // Pass the mapped entity to the repository for addition
                await _rLieuRepository.AddLieuAsync(LieuEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }
    }
}

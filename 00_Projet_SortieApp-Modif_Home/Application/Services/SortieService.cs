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
        private readonly SortieContext _context;

        public ISortieRepository _rsortieRepository { get; set; }

        public SortieService(IMapper mapper, SortieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public SortieDto GetDtoById(int id)
        {
            var sortieEntity = _context.Sortie.FirstOrDefault(p => p.Id == id);
            if (sortieEntity == null)
            {
                return null;
            }

            var sortieDto = _mapper.Map<SortieDto>(sortieEntity);
            return sortieDto;
        }

        public void AddSortie(SortieDto sortieDto)
        {
            try
            {
                var sortieEntity = _mapper.Map<Sortie>(sortieDto);

                // Add the product entity to the context
                //_context.Sortie.Add(sortieEntity);

                // Save changes to the database
                //_context.SaveChanges();
                _rsortieRepository.AddSortie(sortieEntity);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

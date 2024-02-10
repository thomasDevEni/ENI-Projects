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
        private readonly EtatContext _context;

        public IEtatRepository _retatRepository { get; set; }

        public EtatService(IMapper mapper, EtatContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public EtatDto GetDtoById(int id) 
        {
            var etatEntity = _context.Etat.FirstOrDefault(p => p.Id == id);
            if (etatEntity == null) 
            {
                return null;
            }

            var etatDto = _mapper.Map<EtatDto>(etatEntity);
            return etatDto;
        }

        public void AddEtat(EtatDto etatDto)
        {
            try
            {
                var etatEntity = _mapper.Map<Etat>(etatDto);

                // Add the product entity to the context
                //_context.Etat.Add(etatEntity);

                // Save changes to the database
                //_context.SaveChanges();
                _retatRepository.AddEtat(etatEntity);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

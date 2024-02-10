using Application.Dto;
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
        public ISortieRepository _rsortieRepository {  get; set; }

        public SortieService(ISortieRepository rsortieRepository) {
            _rsortieRepository = rsortieRepository;
        }

        public void AddSortie(SortieDto sortie) 
        {
            try
            {
                _rsortieRepository.AddSortie(null);

            } catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

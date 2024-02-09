using Domain.Entities;
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
        public SortieRepository _rsortieRepository {  get; set; }

        public SortieService(SortieRepository rsortieRepository) {
            _rsortieRepository = rsortieRepository;
        }

        public void AddSortie(Sortie sortie) 
        {
            try
            {
                _rsortieRepository.AddSortie(sortie);

            } catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

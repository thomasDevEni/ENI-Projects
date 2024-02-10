using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SortieRepository : ISortieRepository
    {
        public readonly SortieContext _context; 

        public SortieRepository(SortieContext context)
        {
            _context = context;
        }

        public void AddSortie(Sortie sortie)
        {
            try
            {
                _context.Sortie.Add(sortie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

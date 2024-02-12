using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SortieRepository : ISortieRepository
    {
        private readonly SortieContext _context;

        public SortieRepository(SortieContext context)
        {
            _context = context;
        }

        public async Task<Sortie> GetByIdAsync(int id)
        {
            return await _context.Sortie.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<List<Sortie>> GetAllAsync()
        {
            return await _context.Sortie.ToListAsync();
        }

        public async Task<int> AddSortieAsync(Sortie sortie)
        {
            try
            {
                var addedSortie = await _context.Sortie.AddAsync(sortie);
                await _context.SaveChangesAsync();
                return addedSortie.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

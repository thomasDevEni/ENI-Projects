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
    public class LieuRepository:ILieuRepository
    {
        private readonly LieuContext _context;

        public LieuRepository(LieuContext context)
        {
            _context = context;
        }

        public async Task<Lieu> GetByIdAsync(int id)
        {
            return await _context.Lieu.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<List<Lieu>> GetAllAsync()
        {
            return await _context.Lieu.ToListAsync();
        }

        public async Task<int> AddLieuAsync(Lieu lieu)
        {
            try
            {
                var addedLieu = await _context.Lieu.AddAsync(lieu);
                await _context.SaveChangesAsync();
                return addedLieu.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

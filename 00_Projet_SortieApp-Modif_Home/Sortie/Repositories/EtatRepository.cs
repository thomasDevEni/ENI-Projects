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
    public class EtatRepository:IEtatRepository
    {
        private readonly EtatContext _context;

        public EtatRepository(EtatContext context)
        {
            _context = context;
        }

        public async Task<Etat> GetByIdAsync(int id)
        {
            return await _context.Etat.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Etat>> GetAllAsync()
        {
            return await _context.Etat.ToListAsync();
        }

        public async Task<Etat> AddEtatAsync(Etat etat)
        {
            try
            {
                var addedEtat = await _context.Etat.AddAsync(etat);
                await _context.SaveChangesAsync();
                return addedEtat.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
    public class InscriptionRepository:IInscriptionRepository
    {
        public readonly InscriptionContext _context;

        public InscriptionRepository(InscriptionContext context)
        {
            _context = context;
        }

        public async Task<Inscription> GetByIdAsync(int id)
        {
            return await _context.Inscription.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<List<Inscription>> GetAllAsync()
        {
            return await _context.Inscription.ToListAsync();
        }

        public async Task<Inscription> AddInscriptionAsync(Inscription inscription)
        {
            try
            {
                var addedInscription = await _context.Inscription.AddAsync(inscription);
                await _context.SaveChangesAsync();
                return addedInscription.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InscriptionRepository : IInscriptionRepository
    {
        private readonly InscriptionContext _context;

        public InscriptionRepository(InscriptionContext context)
        {
            _context = context;
        }

        public async Task<Inscription?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Inscription.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Inscription>> GetAllAsync()
        {
            return await _context.Inscription.Where(inscription => inscription.IsActive).ToListAsync();
        }

        public async Task<int> AddInscriptionAsync(Inscription inscription)
        {
            try
            {
                inscription.IsActive = true;
                var addedInscription = await _context.Inscription.AddAsync(inscription);
                await _context.SaveChangesAsync();
                return addedInscription.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateInscriptionAsync(Inscription inscription)
        {
            // Retrieve the existing Inscription entity from the database

            // Update other properties as necessary
            _context.Update(inscription);
            // Save the changes back to the database
            await _context.SaveChangesAsync();

        }

        public async Task DeleteInscriptionAsync(int id)
        {
            // Retrieve the existing Inscription entity from the database
            var inscriptionToDelete = await _context.Inscription.FindAsync(id);

            if (inscriptionToDelete != null)
            {
                // Remove the Inscription entity from the database
                inscriptionToDelete.IsActive = false;
                //_context.Inscription.Remove(inscriptionToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Inscription entity with the provided Id does not exist
                throw new NotFoundException($"Inscription with Id {id} not found.");
            }
        }
    }
}

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
    public class EtatRepository:IEtatRepository
    {
        private readonly EtatContext _context;

        public EtatRepository(EtatContext context)
        {
            _context = context;
        }

        public async Task<Etat?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Etat.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }
            
        }

        public async Task<List<Etat>> GetAllAsync()
        {
            return await _context.Etat.Where(etat => etat.IsActive).ToListAsync();
        }

        public async Task<int> AddEtatAsync(Etat etat)
        {
            try
            {
                etat.IsActive = true;
                var addedEtat = await _context.Etat.AddAsync(etat);
                await _context.SaveChangesAsync();
                return addedEtat.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEtatAsync(Etat etat)
        {
            // Retrieve the existing Etat entity from the database

            // Update other properties as necessary
            _context.Update(etat);
            // Save the changes back to the database
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEtatAsync(int id)
        {
            // Retrieve the existing Etat entity from the database
            var etatToDelete = await _context.Etat.FindAsync(id);

            if (etatToDelete != null)
            {
                // Remove the Etat entity from the database
                etatToDelete.IsActive = false;
                //_context.Etat.Remove(etatToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Etat entity with the provided Id does not exist
                throw new NotFoundException($"Etat with Id {id} not found.");
            }
        }
    }

    [Serializable]
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

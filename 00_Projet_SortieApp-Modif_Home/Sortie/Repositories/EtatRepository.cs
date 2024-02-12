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

        public async Task<Etat> GetByIdAsync(int id)
        {
            return await _context.Etat.FirstOrDefaultAsync(c => c.Id == id);
        }

         

        public async Task<List<Etat>> GetAllAsync()
        {
            return await _context.Etat.ToListAsync();
        }

        public async Task<int> AddEtatAsync(Etat etat)
        {
            try
            {
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
            var existingEtat = await _context.Etat.FindAsync(etat.Id);

            if (existingEtat != null)
            {
                // Update the properties of the existing Etat entity with values from etatDto
                existingEtat.Libelle = etat.Libelle;
                // Update other properties as necessary

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Etat entity with the provided Id does not exist
                throw new NotFoundException($"Etat with Id {etat.Id} not found.");
            }
        }

        public async Task DeleteEtatAsync(int id)
        {
            // Retrieve the existing Etat entity from the database
            var etatToDelete = await _context.Etat.FindAsync(id);

            if (etatToDelete != null)
            {
                // Remove the Etat entity from the database
                _context.Etat.Remove(etatToDelete);

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

using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InscriptionRepository:IInscriptionRepository
    {
        private readonly InscriptionContext _context;

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

        public async Task<int> AddInscriptionAsync(Inscription inscription)
        {
            try
            {
                var addedEtat = await _context.Inscription.AddAsync(inscription);
                await _context.SaveChangesAsync();
                return addedEtat.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateInscriptionAsync(Inscription inscription)
        {
            // Retrieve the existing Inscription entity from the database
            var existingInscription = await _context.Inscription.FindAsync(inscription.Id);

            if (existingInscription != null)
            {
                // Update the properties of the existing Inscription entity with values from inscriptionDto
                existingInscription.ParticipantId = inscription.ParticipantId;
                // Update other properties as necessary

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Inscription entity with the provided Id does not exist
                throw new NotFoundException($"Inscription with Id {inscription.Id} not found.");
            }
        }

        public async Task DeleteInscriptionAsync(int id)
        {
            // Retrieve the existing Inscription entity from the database
            var inscriptionToDelete = await _context.Inscription.FindAsync(id);

            if (inscriptionToDelete != null)
            {
                // Remove the Inscription entity from the database
                _context.Inscription.Remove(inscriptionToDelete);

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

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
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ParticipantContext _context;

        public ParticipantRepository(ParticipantContext context)
        {
            _context = context;
        }

        public async Task<Participant?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Participant.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participant.Where(participant => participant.IsActive).ToListAsync();
        }

        public async Task<int> AddParticipantAsync(Participant participant)
        {
            try
            {
                participant.IsActive = true;
                var addedParticipant = await _context.Participant.AddAsync(participant);
                await _context.SaveChangesAsync();
                return addedParticipant.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateParticipantAsync(Participant participant)
        {
            // Retrieve the existing Participant entity from the database

            // Update other properties as necessary
            _context.Update(participant);
            // Save the changes back to the database
            await _context.SaveChangesAsync();

        }

        public async Task DeleteParticipantAsync(int id)
        {
            // Retrieve the existing Participant entity from the database
            var participantToDelete = await _context.Participant.FindAsync(id);

            if (participantToDelete != null)
            {
                // Remove the Participant entity from the database
                participantToDelete.IsActive = false;
                //_context.Participant.Remove(participantToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Participant entity with the provided Id does not exist
                throw new NotFoundException($"Participant with Id {id} not found.");
            }
        }
    }
}

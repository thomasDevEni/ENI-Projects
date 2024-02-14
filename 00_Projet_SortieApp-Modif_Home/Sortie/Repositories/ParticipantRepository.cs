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
                participant.Protected = false;
                //Tout nouveau participant aura le role d'utilisateur: seul le superadmin peut changer ce role
                participant.RoleId = 2;
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
            if (participant.Protected != true)
            { // Update other properties as necessary
                _context.Update(participant);
                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            if (participant.Protected == true)
            { // Update other properties as necessary
                await Console.Out.WriteLineAsync("On ne met pas à jour un participant protégé");
            }
            else
            {
                // Handle the case where the Participant entity with the provided Id does not exist
                throw new NotFoundException("L'Participant est protégé");
            }
        }

        public async Task DeleteParticipantAsync(int id)
        {
            // Retrieve the existing Participant entity from the database
            var participantToDelete = await _context.Participant.FindAsync(id);

            if (participantToDelete != null && participantToDelete.Protected != true)
            {
                // Put Participant to inactive in database
                participantToDelete.IsActive = false;
                //_context.Participant.Remove(participantToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            if (participantToDelete != null && participantToDelete.Protected == true)
            {
                // On ne supprime pas un Participant protégé
                await Console.Out.WriteLineAsync("On ne supprime pas un participant protégé.");
                //throw new NotFoundException($"Participant avec Id {id} protégé.");
            }
            else
            {

                // Handle the case where the Participant entity with the provided Id does not exist
                throw new NotFoundException($"Participant with Id {id} not found.");
            }
        }
    }
}

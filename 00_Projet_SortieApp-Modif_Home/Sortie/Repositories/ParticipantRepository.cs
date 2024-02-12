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
    public class ParticipantRepository:IParticipantRepository
    {
        private readonly ParticipantContext _context;

        public ParticipantRepository(ParticipantContext context)
        {
            _context = context;
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _context.Participant.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participant.ToListAsync();
        }

        public async Task<Participant> AddParticipantAsync(Participant participant)
        {
            try
            {
                var addedParticipant = await _context.Participant.AddAsync(participant);
                await _context.SaveChangesAsync();
                return addedParticipant.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

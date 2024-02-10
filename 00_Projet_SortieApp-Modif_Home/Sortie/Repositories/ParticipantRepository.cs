using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ParticipantRepository:IParticipantRepository
    {
        public readonly ParticipantContext _context;

        public ParticipantRepository(ParticipantContext context)
        {
            _context = context;
        }

        public void AddParticipant(Participant participant)
        {
            try
            {
                _context.Participant.Add(participant);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

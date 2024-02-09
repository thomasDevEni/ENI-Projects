using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ParticipantService : IParticipantService
    {
        public ParticipantRepository _rparticipantRepository { get; set; }

        public ParticipantService(ParticipantRepository rparticipantRepository)
        {
            _rparticipantRepository = rparticipantRepository;
        }

        public void AddParticipant(Participant participant)
        {
            try
            {
                _rparticipantRepository.AddParticipant(participant);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IParticipantRepository
    {
        Task<Participant> AddParticipantAsync(Participant participant);
        Task<Participant> GetByIdAsync(int id);

        Task<List<Participant>> GetAllAsync();
    }
}

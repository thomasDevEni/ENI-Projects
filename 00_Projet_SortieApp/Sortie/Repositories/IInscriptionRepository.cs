using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IInscriptionRepository
    {
        Task<int> AddInscriptionAsync(Inscription inscription);
        Task<Inscription> GetByIdAsync(int id);

        Task<List<Inscription>> GetAllAsync();

        Task UpdateInscriptionAsync(Inscription inscription);

        Task DeleteInscriptionAsync(int id);
    }
}

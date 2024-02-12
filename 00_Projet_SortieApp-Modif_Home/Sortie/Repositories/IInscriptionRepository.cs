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
        Task<Inscription> AddInscriptionAsync(Inscription inscription);
        Task<Inscription> GetByIdAsync(int id);

        Task<List<Inscription>> GetAllAsync();
    }
}

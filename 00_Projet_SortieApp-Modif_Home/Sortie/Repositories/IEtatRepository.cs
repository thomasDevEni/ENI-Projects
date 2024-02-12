using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IEtatRepository
    {
        Task<int> AddEtatAsync(Etat etat);
        Task<Etat> GetByIdAsync(int id);

        Task<List<Etat>> GetAllAsync();
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ISortieRepository
    {
        Task<Sortie> AddSortieAsync(Sortie sortie);
        Task<Sortie> GetByIdAsync(int id);

        Task<List<Sortie>> GetAllAsync();
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ILieuRepository
    {
        Task<int> AddLieuAsync(Lieu lieu);
        Task<Lieu> GetByIdAsync(int id);

        Task<List<Lieu>> GetAllAsync();
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRoleRepository
    {
        Task<int> AddRoleAsync(Role role);
        Task<Role> GetByIdAsync(int id);

        Task<List<Role>> GetAllAsync();
    }
}

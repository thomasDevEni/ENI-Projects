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
    public class RoleRepository:IRoleRepository
    {
        private readonly RoleContext _context;

        public RoleRepository(RoleContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Role.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            try
            {
                var addedrole = await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return addedrole.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

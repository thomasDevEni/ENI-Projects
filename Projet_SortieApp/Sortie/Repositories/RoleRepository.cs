using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository
    {
        public readonly RoleContext _context;

        public RoleRepository(RoleContext context)
        {
            _context = context;
        }

        public void AddRole(Role role)
        {
            try
            {
                _context.Role.Add(role);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

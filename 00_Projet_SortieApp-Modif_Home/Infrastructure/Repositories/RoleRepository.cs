using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleContext _context;

        public RoleRepository(RoleContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Role.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Role.Where(role => role.IsActive).ToListAsync();
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            try
            {
                role.IsActive = true;
                role.Protected = false;
                var addedRole = await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return addedRole.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateRoleAsync(Role role)
        {
            // Retrieve the existing Role entity from the database
            if (role.Protected != true)
            { // Update other properties as necessary
                _context.Update(role);
                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            if (role.Protected == true)
            { // Update other properties as necessary
                await Console.Out.WriteLineAsync("On ne met pas à jour un role protégé");
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            // Retrieve the existing Role entity from the database
            var roleToDelete = await _context.Role.FindAsync(id);

            if (roleToDelete != null && roleToDelete.Protected != true)
            {
                // Put Role to inactive in database
                roleToDelete.IsActive = false;
                //_context.Role.Remove(roleToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            if (roleToDelete != null && roleToDelete.Protected == true)
            {
                // On ne supprime pas un Role protégé
                await Console.Out.WriteLineAsync("On ne supprime pas un role protégé.");
                //throw new NotFoundException($"Role avec Id {id} protégé.");
            }
            else
            {

                // Handle the case where the Role entity with the provided Id does not exist
                throw new NotFoundException($"Role with Id {id} not found.");
            }
        }
    }
}

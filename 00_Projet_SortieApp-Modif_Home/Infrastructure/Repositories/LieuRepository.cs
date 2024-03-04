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
    public class LieuRepository : ILieuRepository
    {
        private readonly LieuContext _context;

        public LieuRepository(LieuContext context)
        {
            _context = context;
        }

        public async Task<Lieu?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Lieu.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Lieu>> GetAllAsync()
        {
            return await _context.Lieu.Where(lieu => lieu.IsActive).ToListAsync();
        }

        public async Task<int> AddLieuAsync(Lieu lieu)
        {
            try
            {
                lieu.IsActive = true;
                var addedLieu = await _context.Lieu.AddAsync(lieu);
                await _context.SaveChangesAsync();
                return addedLieu.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateLieuAsync(Lieu lieu)
        {
            // Retrieve the existing Lieu entity from the database

            // Update other properties as necessary
            _context.Update(lieu);
            // Save the changes back to the database
            await _context.SaveChangesAsync();

        }

        public async Task DeleteLieuAsync(int id)
        {
            // Retrieve the existing Lieu entity from the database
            var lieuToDelete = await _context.Lieu.FindAsync(id);

            if (lieuToDelete != null)
            {
                // Remove the Lieu entity from the database
                lieuToDelete.IsActive = false;
                //_context.Lieu.Remove(lieuToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Lieu entity with the provided Id does not exist
                throw new NotFoundException($"Lieu with Id {id} not found.");
            }
        }
    }
}

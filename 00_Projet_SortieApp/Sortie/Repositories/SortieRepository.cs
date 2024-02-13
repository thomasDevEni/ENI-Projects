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
    public class SortieRepository : ISortieRepository
    {
        private readonly SortieContext _context;

        public SortieRepository(SortieContext context)
        {
            _context = context;
        }

        public async Task<Sortie?> GetByIdAsync(int id)
        {
            var itemFound = await _context.Sortie.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Sortie>> GetAllAsync()
        {
            return await _context.Sortie.Where(sortie => sortie.IsActive).ToListAsync();
        }

        public async Task<int> AddSortieAsync(Sortie sortie)
        {
            try
            {
                sortie.IsActive = true;
                var addedSortie = await _context.Sortie.AddAsync(sortie);
                await _context.SaveChangesAsync();
                return addedSortie.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateSortieAsync(Sortie sortie)
        {
            // Retrieve the existing Sortie entity from the database

            // Update other properties as necessary
            _context.Update(sortie);
            // Save the changes back to the database
            await _context.SaveChangesAsync();

        }

        public async Task DeleteSortieAsync(int id)
        {
            // Retrieve the existing Sortie entity from the database
            var sortieToDelete = await _context.Sortie.FindAsync(id);

            if (sortieToDelete != null)
            {
                // Remove the Sortie entity from the database
                sortieToDelete.IsActive = false;
                //_context.Sortie.Remove(sortieToDelete);

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Sortie entity with the provided Id does not exist
                throw new NotFoundException($"Sortie with Id {id} not found.");
            }
        }
    }
}

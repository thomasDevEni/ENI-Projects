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
    public class LieuRepository:ILieuRepository
    {
        private readonly LieuContext _context;

        public LieuRepository(LieuContext context)
        {
            _context = context;
        }

        public async Task<Lieu> GetByIdAsync(int id)
        {
            return await _context.Lieu.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<List<Lieu>> GetAllAsync()
        {
            return await _context.Lieu.ToListAsync();
        }

        public async Task<int> AddLieuAsync(Lieu lieu)
        {
            try
            {
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
            var existingLieu = await _context.Lieu.FindAsync(lieu.Id);

            if (existingLieu != null)
            {
                // Update the properties of the existing Lieu entity with values from lieuDto
                existingLieu.Etablissement = lieu.Etablissement;
                // Update other properties as necessary

                // Save the changes back to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the Lieu entity with the provided Id does not exist
                throw new NotFoundException($"Lieu with Id {lieu.Id} not found.");
            }
        }

        public async Task DeleteLieuAsync(int id)
        {
            // Retrieve the existing Lieu entity from the database
            var lieuToDelete = await _context.Lieu.FindAsync(id);

            if (lieuToDelete != null)
            {
                // Remove the Lieu entity from the database
                _context.Lieu.Remove(lieuToDelete);

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

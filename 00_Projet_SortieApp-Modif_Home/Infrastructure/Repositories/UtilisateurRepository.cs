using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UtilisateurRepository:IUtilisateurRepository
    {
        private readonly UtilisateurContext _userContext;

        public UtilisateurRepository(UtilisateurContext userContext)
        {
            _userContext = userContext;
        }

        //Hash the Password During User Registration
        private static string HashPassword(string password)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Hash the password
            return hasher.HashPassword(null, password);
        }

        public async Task<Utilisateur> GetUserByUsernameAsync(string username)
        {
            return await _userContext.Utilisateur.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Utilisateur> GetHashedPassword(string username)
        {
            return await _userContext.Utilisateur.FirstOrDefaultAsync(u => u.Username == username);
         }

        public async Task<int> AddUserAsync(Utilisateur user)
        {
            try
            {
                user.IsActive = true;
                user.Protected = false;
                //Tout nouvel utilisateur aura le role d'utilisateur: seul le superadmin pourra changer ce role
                user.RoleId = 2;
                var addedUser = await _userContext.Utilisateur.AddAsync(user);
                await _userContext.SaveChangesAsync();
                return addedUser.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Utilisateur?> GetByIdAsync(int id)
        {
            var itemFound = await _userContext.Utilisateur.FirstOrDefaultAsync(c => c.Id == id);

            if (itemFound == null) { return null; }
            if (itemFound.IsActive == true) { return itemFound; }

            else { return null; }

        }

        public async Task<List<Utilisateur>> GetAllAsync()
        {
            return await _userContext.Utilisateur.Where(utilisateur => utilisateur.IsActive).ToListAsync();
        }

        
        public async Task UpdateUserAsync(Utilisateur utilisateur)
        {
            // Retrieve the existing Utilisateur entity from the database
            if (utilisateur.Protected != true)
            { // Update other properties as necessary
                _userContext.Update(utilisateur);
                // Save the changes back to the database
                await _userContext.SaveChangesAsync();
            }
            if (utilisateur.Protected == true)
            { // Update other properties as necessary
                await Console.Out.WriteLineAsync("On ne met pas à jour un utilisateur protégé");
            }
            else
            {
                // Handle the case where the Utilisateur entity with the provided Id does not exist
                throw new NotFoundException("L'Utilisateur est protégé");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            // Retrieve the existing Utilisateur entity from the database
            var utilisateurToDelete = await _userContext.Utilisateur.FindAsync(id);

            if (utilisateurToDelete != null && utilisateurToDelete.Protected != true)
            {
                // Put Utilisateur to inactive in database
                utilisateurToDelete.IsActive = false;
                //_context.Utilisateur.Remove(utilisateurToDelete);

                // Save the changes back to the database
                await _userContext.SaveChangesAsync();
            }
            if (utilisateurToDelete != null && utilisateurToDelete.Protected == true)
            {
                // On ne supprime pas un Utilisateur protégé
                await Console.Out.WriteLineAsync("On ne supprime pas un utilisateur protégé.");
                //throw new NotFoundException($"Utilisateur avec Id {id} protégé.");
            }
            else
            {

                // Handle the case where the Utilisateur entity with the provided Id does not exist
                throw new NotFoundException($"Utilisateur with Id {id} not found.");
            }
        }
    }
}

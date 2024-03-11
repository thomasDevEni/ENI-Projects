using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUtilisateurRepository
    {
        Task<Utilisateur> GetUserByUsernameAsync(string username);
        Task<Utilisateur> GetHashedPassword(string username);
        Task<int> AddUserAsync(Utilisateur user);
        Task<Utilisateur> GetByIdAsync(int id);

        Task<List<Utilisateur>> GetAllAsync();

        Task UpdateUserAsync(Utilisateur utilisateur);

        Task DeleteUserAsync(int id);
    }
}

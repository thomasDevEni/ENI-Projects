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
    public class UserRepository:IUserRepository
    {
        private readonly LoginContext _userContext;

        public UserRepository(LoginContext userContext)
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

        public async Task<Login> GetUserByUsernameAsync(string username)
        {
            return await _userContext.Login.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Login> GetHashedPassword(string username)
        {
            return await _userContext.Login.FirstOrDefaultAsync(u => u.Username == username);
         }

        public async Task<int> AddUserAsync(Login user)
        {
            try
            {
                user.IsActive = true;
                user.Protected = false;
                //Tout nouvel utilisateur aura le role d'utilisateur: seul le superadmin pourra changer ce role
                user.RoleId = 2;
                var addedUser = await _userContext.Login.AddAsync(user);
                await _userContext.SaveChangesAsync();
                return addedUser.Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

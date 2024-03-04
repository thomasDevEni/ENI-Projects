using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<Login> GetUserByUsernameAsync(string username);
        Task<Login> GetHashedPassword(string username);
        Task<int> AddUserAsync(Login user);
    }
}

using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        public RoleRepository _rroleRepository { get; set; }

        public RoleService(RoleRepository rroleRepository)
        {
            _rroleRepository = rroleRepository;
        }

        public void AddRole(Role role)
        {
            try
            {
                _rroleRepository.AddRole(role);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

using Application.Dto;
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
        public IRoleRepository _rroleRepository { get; set; }

        public RoleService(IRoleRepository rroleRepository)
        {
            _rroleRepository = rroleRepository;
        }

        public void AddRole(RoleDto role)
        {
            try
            {
                _rroleRepository.AddRole(null);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

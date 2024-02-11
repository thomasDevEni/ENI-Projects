using Application.Dto;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IRoleRepository _rroleRepository;


        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _rroleRepository = roleRepository;
        }



        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = _rroleRepository.GetByIdAsync(id);
            if (_rroleRepository == null)
            {
                return null;
            }

            var roleDto = _mapper.Map<RoleDto>(role);
            return roleDto;
        }

        public async Task<List<RoleDto>> GetAllRoleAsync()
        {
            var roles = await _rroleRepository.GetAllAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var role = await _rroleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task AddRoleAsync(RoleDto roleDto)
        {
            try
            {
                // Map EtattDto to Etat entity
                var roleEntity = _mapper.Map<Role>(roleDto);

                // Pass the mapped entity to the repository for addition
                await _rroleRepository.AddRoleAsync(roleEntity);


            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}

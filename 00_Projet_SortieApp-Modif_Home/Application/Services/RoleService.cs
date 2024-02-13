using Application.Dto;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _rroleRepository;
        private readonly IValidator<RoleDto> _roleValidator;

        public RoleService(IMapper mapper, IRoleRepository roleRepository, IValidator<RoleDto> roleValidator)
        {
            _mapper = mapper;
            _rroleRepository = roleRepository;
            _roleValidator = roleValidator;
        }

        public ValidationResult ValidateRole(RoleDto role)
        {
            return _roleValidator.Validate(role);
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = _rroleRepository.GetByIdAsync(id); ;
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

        public async Task<RoleDto?> GetRoleByIdAsync(int id)
        {
            var product = await _rroleRepository.GetByIdAsync(id);
            if (product == null) { return null; }
            else { return _mapper.Map<RoleDto>(product); }
        }

        public async Task AddRoleAsync(RoleDto roleDto)
        {
            try
            {
                // Map RoletDto to Role entity
                var roleEntity = _mapper.Map<Role>(roleDto);

                // Pass the mapped entity to the repository for addition
                await _rroleRepository.AddRoleAsync(roleEntity);


            }
            catch (Exception ex)

            {
                throw new Exception();
            }
        }

        public async Task UpdateRoleAsync(RoleDto? roleDto)
        {

            if (roleDto != null)
            {
                var roleEntity = await _rroleRepository.GetByIdAsync(roleDto.Id);
                if (roleEntity == null)
                {
                    // Handle the case where the Role entity with the provided Id does not exist
                    throw new Exception("Elément non trouvé");
                }
                if (roleEntity != null)
                {   // Update the properties of the existing Role entity with values from roleDto
                    roleEntity.Libelle = roleDto.Libelle;
                    // Save the changes back to the database
                    await _rroleRepository.UpdateRoleAsync(roleEntity);

                }

            }
            else
            {
                // Handle the case where the Role entity with the provided Id does not exist
                throw new Exception();
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            // Retrieve the existing Role entity from the database
            var roleToDelete = await _rroleRepository.GetByIdAsync(id);

            if (roleToDelete != null)
            {
                // Remove the Role entity from the database
                await _rroleRepository.DeleteRoleAsync(id);
            }
            else
            {
                // Handle the case where the Role entity with the provided Id does not exist
                throw new Exception();
            }
        }
    }
}

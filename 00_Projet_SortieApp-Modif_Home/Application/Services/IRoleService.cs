using Application.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoleService
    {
        Task AddRoleAsync(RoleDto roleDto);
        Task<RoleDto> GetByIdAsync(int id);
        Task<List<RoleDto>> GetAllRoleAsync();

        Task<RoleDto> GetRoleByIdAsync(int id);

        ValidationResult ValidateRole(RoleDto role);
    }
}

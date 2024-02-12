using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using FluentValidation;


namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IValidator<RoleDto> _roleValidator;

        public RoleController(IRoleService roleService, IValidator<RoleDto> roleValidator)
        {
            _roleService = roleService;
            _roleValidator = roleValidator;
        }

        
        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var role = await _roleService.GetAllRoleAsync();
            return Ok(role);
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST: api/Role
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync(RoleDto roleDto)
        {
            try
            {
                var result = _roleService.ValidateRole(roleDto);
                if (!result.IsValid) {
                    return BadRequest(result.Errors);
                }

                await _roleService.AddRoleAsync(roleDto);
                return Ok();
                //return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

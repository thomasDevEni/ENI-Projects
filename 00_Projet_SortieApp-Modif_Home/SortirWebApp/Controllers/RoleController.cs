using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;


namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
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
        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(RoleDto roleDto)
        {
            try
            {
                await _roleService.AddRoleAsync(roleDto);
                return Ok(_roleService);
                //return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace SortieWebApp.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        public RoleService _roleService { get; set; }
        public RoleController(RoleService RoleService) 
        {
        _roleService = RoleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            try
            {
                _roleService.AddRole(role);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

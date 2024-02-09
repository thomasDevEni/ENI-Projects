using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dto;


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
        public async Task<IActionResult> AddRole(RoleDto roleDto)
        {
            try
            {
                _roleService.AddRole(roleDto);
                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

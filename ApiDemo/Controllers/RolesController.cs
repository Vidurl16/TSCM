using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{RoleId}")]
        public async Task<ActionResult<Role>> GetRole(int roleId)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(roleId);

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            try
            {
                var newRoleId = await _roleService.AddRoleAsync(role);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetRole", new { RoleId = newRoleId });
                return Created(location, role);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{RoleId}")]
        public async Task<IActionResult> UpdateRole(int roleId, Role updatedRole)
        {
            try
            {
                var success = await _roleService.UpdateRoleAsync(updatedRole);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{RoleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            try
            {
                var success = await _roleService.DeleteRoleAsync(roleId);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

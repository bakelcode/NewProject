using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsProject.Shared.Dtos.Administrations;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdministrationsController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var roles = await _roleManager.FindByIdAsync(id);
            return Ok(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RolesDto role)
        {
            if (role == null || !ModelState.IsValid)
            {
                return BadRequest("Can't Add Role");
            }
            IdentityRole identityRole = new IdentityRole() { Name = role.Name };
            var result = await _roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new AddRoleResponseDto { Errors = errors});
            }
            return StatusCode(201);
        }
        [HttpPut]
        public async Task<IActionResult> EditRole([FromBody] RolesDto Currole)
        {
            var role = await _roleManager.FindByIdAsync(Currole.Id);
            if (role == null)
            {
                return NotFound("Can't Find Role");
            }
            role.Name = Currole.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new AddRoleResponseDto { Errors = errors });
            }
            return StatusCode(202);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string RoleId)
        {
            var role = await _roleManager.FindByIdAsync(RoleId);
            if (role == null)
            {
                return NotFound("Can't Find Role");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new AddRoleResponseDto { Errors = errors });
            }
            return StatusCode(202);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsProject.Shared.Dtos.Accounts;
using NewsProject.Shared.Dtos.Administrations;
using NewsProject.Shared.Models;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersList = await _userManager.Users.ToListAsync();
            var user = usersList.Select(u => new ApplicationUser()
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserRoles = String.Join(", ", _userManager.GetRolesAsync(u).Result.ToArray())
            });
            if (user == null)
            {
                return BadRequest("No users found");
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            var users = await _userManager.FindByNameAsync(userName);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var users = await _userManager.FindByEmailAsync(userEmail);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet("{UserId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserWithRoles(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            var _roles = await _roleManager.Roles.ToListAsync();
            var UserRoles = new UsersRolesDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = _roles.Select(r=> new SelectedRolesDto
                {
                    Name = r.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList()
            };
            return Ok(UserRoles);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserRoles(UsersRolesDto usersRoles)
        {
            var _user = await _userManager.FindByIdAsync(usersRoles.Id);
            if (_user == null)
            {
                return NotFound();
            }
            foreach(var role in usersRoles.Roles)
            {
                if (role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(_user, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(_user, role.Name);
                }
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByNameAsync(changePassword.UserName);
            var newPassword = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            if (user == null)
            {
                return NotFound();
            }
            if (!newPassword.Succeeded)
            {
                return Unauthorized(new RegistrationResponseDto { Errors = new[] { "Invalid Password" } });
            }

            return Ok(user);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto usermodel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(usermodel.Email);
                if (user == null)
                {
                    return BadRequest("Email not found");
                }
                
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var psswordResetLink = $"{usermodel.WebLink}?email={usermodel.Email}&token={token}";
                await _emailSender.SendEmailAsync(usermodel.Email, "Reset Password", $"<p>Hi {user.UserName},</p> <p>To reset your password please <a href={psswordResetLink}>CLICK HERE</a>");
                return Ok("Eamil sent");
            }
            return BadRequest("Can't send email");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto reset)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(reset.Email);
                if (user == null)
                {
                    return NotFound();
                }
                string NewToken = reset.Token.Replace(" ", "+");
                var result = await _userManager.ResetPasswordAsync(user, NewToken, reset.Password);
                if (!result.Succeeded)
                {
                    return BadRequest("Can't reser password");
                }
                return Ok();
            }
            return BadRequest("Can't reser password");
        }
    }
}

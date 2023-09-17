using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NewsProject.Shared.Dtos.Accounts;
using NewsProject.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public AccountsController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWTSettings");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserregistrationDto userregistration)
        {
            if (userregistration == null || !ModelState.IsValid)
            {
                return BadRequest("Can not register user");
            }

            var user = new ApplicationUser()
            {
                UserName = userregistration.UserName,
                Email = userregistration.UserEmail
            };
            var result = await _userManager.CreateAsync(user, userregistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            await _userManager.AddToRoleAsync(user, "Viewer");
            return StatusCode(201);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(login.UserName);
            }

            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return Unauthorized(new LoginResponseDto { Errors = new[] { "Faild to login" } });
            }
            var signinCredentials = GetSigningCredentials();
            var Claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signinCredentials, Claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new LoginResponseDto { IsLogInSuccessful = true, Token = token });
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var _roles = await _userManager.GetRolesAsync(user);
            foreach (var role in _roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expirinMinutes"])),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

    }
}

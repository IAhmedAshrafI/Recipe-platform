using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities.AppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Login = Domain.Entities.AppUser.Login;
using Register = Domain.Entities.AppUser.Register;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
      private readonly UserManager<AppUser> _userManager;
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly IConfiguration _configuration;

      public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
      {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
      }

      [HttpPost("register")]
      public async Task<IActionResult> Register([FromBody] Register model)
      {
        // Create a new IdentityUser object
        var user = new AppUser { UserName = model.Username, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
          // Check if the role exists
          if (!await _roleManager.RoleExistsAsync(model.Role))
          {
            return BadRequest(new { message = "Role does not exist" });
          }

          // Assign the role to the user
          var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

          if (!roleResult.Succeeded)
          {
            return BadRequest(roleResult.Errors);
          }

          return Ok(new { message = "User registered successfully with role assigned" });
        }

        return BadRequest(result.Errors);
      }

      [HttpPost("login")]
      public async Task<IActionResult> Login([FromBody] Login model)
      {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
          var userRoles = await _userManager.GetRolesAsync(user);

          var authClaims = new List<Claim>
          {
            new Claim(ClaimTypes.NameIdentifier, user.Id), // Add user ID here
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!), // Add username
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unique token ID
          };

          authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

          var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
            claims: authClaims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
              SecurityAlgorithms.HmacSha256));

          return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
      }

      [HttpPost("add-role")]
      public async Task<IActionResult> AddRole([FromBody] string role)
      {
        if (!await _roleManager.RoleExistsAsync(role))
        {
          var result = await _roleManager.CreateAsync(new IdentityRole(role));
          if (result.Succeeded)
          {
            return Ok(new { message = "Role added successfully" });
          }

          return BadRequest(result.Errors);
        }

        return BadRequest("Role already exists");
      }
    }
}

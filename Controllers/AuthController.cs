using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingManager.Data;
using BookingManager.DTOs;
using BookingManager.Models;
using BookingManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BookingManagerDBContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(BookingManagerDBContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("Register")] 
        public async  Task<IActionResult> Register(AdminRegisterDTO newAdmin)
        {
            var existing = _context.Admins.FirstOrDefault(a => a.Username == newAdmin.Username);
            if (existing != null)
            {
                return BadRequest("Username already exists");
            }
            var password = BCrypt.Net.BCrypt.HashPassword(newAdmin.Password);
            var admin = new Admin
            {
                Username = newAdmin.Username,
                PasswordHash = password
            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return Ok("Admin registered");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginDTO loginAdmin)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == loginAdmin.Username);
            if (admin == null)
            {
                return Unauthorized("Invalid username or password");
            }

            bool passwordMatching = BCrypt.Net.BCrypt.Verify(loginAdmin.Password, admin.PasswordHash);
            if (!passwordMatching)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _tokenService.GenerateToken(admin);


            return Ok(new { token }); 
        }

    }
}

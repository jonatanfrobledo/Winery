using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Winery.Dtos;
using Winery.Entities;
using Winery.Services;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto loginDto)
        {
            // Validación básica de los datos de entrada
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Username) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Los datos de inicio de sesión no son válidos.");
            }

            User? user = _userService.AuthenticateUser(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }

            // Crear la clave de seguridad
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            // Crear los claims para el token
            var claimsForToken = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username)
            };

            // Generar el token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            // Retornar el token
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
            
        }
    }
}

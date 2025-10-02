using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop.DATA.Entities;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            try
            {
                userDto = await _userService.Register(userDto);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            UserDto userDto = await _userService.Login(loginDto.Username, loginDto.Password);
            if (userDto == null)
            {
                return Unauthorized("Invalid username or password!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginDto.Username),
                new Claim(ClaimTypes.Role, "user")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { 
                token = jwt,
                user = new
                {
                    user = new
                    {
                        userDto.Username,
                        userDto.Name,
                        userDto.Email,
                        userDto.Age
                    }
                }
                });
        }
    }
}

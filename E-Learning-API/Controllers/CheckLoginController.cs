using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using E_Learning_API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckLoginController : ControllerBase
    {
        private readonly ISystemManagementService _systemManagementService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public CheckLoginController(ISystemManagementService systemManagementService,
            IConfiguration config,
            IAuthService authService)
        {
            _config = config;
            _authService = authService;
            _systemManagementService = systemManagementService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string account)
        {
            bool checkExistUser = await _systemManagementService.CheckExistUser(account);
            if (!checkExistUser)
            {
                return NotFound();
            }
            var userFromService = await _authService.GetUser(account);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromService.USER_GUID.ToString()),
                new Claim(ClaimTypes.Name, userFromService.NAME)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user = userFromService
            });
        }
    }
}
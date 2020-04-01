using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using E_Learning_API.Application.Implementation;

namespace E_Learning_API.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService, IConfiguration config, IMapper mapper)
        {
            _authService = authService;
            _config = config;
            _mapper = mapper;

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserForLoginViewModel userForLoginViewModel)
        {
            var userFromService = await _authService.Login(userForLoginViewModel.UserName, userForLoginViewModel.Password);
            bool administrator = await _authService.IsAdministrator(userForLoginViewModel.Password.Trim());

            if (userFromService == null)
                return Unauthorized();

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
                user  = userFromService
            });
        }

        [HttpGet("[action]/{account}")]
        public async Task<bool> IsAdministrator(string account)
        {
            bool check = await _authService.IsAdministrator(account.Trim());
            return check;
        }
    }
}
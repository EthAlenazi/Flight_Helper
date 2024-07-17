using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Data;
using WebAPI.DTO.Create;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserServices _user;

        public AuthenticationController(IConfiguration configuration, IUserServices user)
        {
            _user = user;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var StaticUser = await _user.IsValidStaticUser(login);
            var DynamicUser = await _user.IsValidDynamicUser(login);
            if (StaticUser || DynamicUser)
            {
                var token = _user.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(UserDTO model)
        {
            var result = await _user.CreateUser(model);
            if(result)
                return Ok(result); 
            return NotFound("something happened! Contact with customer service to help you");
        }

    }
}

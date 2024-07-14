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
        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn(AuthenticationDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var user = await _user.ValidateUserCredentials(model.UserName, model.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(UserDTO model)
        {
            var result = await _user.CreateUser(model);
            return Ok(result);
        }

    }
}

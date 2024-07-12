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
    [Route("api/authentication/{Controller}")]
    [ApiController]
    [ApiVersion(3)] //This for versioning All API inside controller
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserServices _user;

        public AuthenticationController(IConfiguration configuration, IUserServices user)
        {
            _user = user;
        }
        [HttpPost("LogIn")]
        [ApiVersion(0.1, Deprecated = true)]//To inform user this version will expired
        public async Task<ActionResult<string>> Authenticate(AuthenticationModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var user = await _user.ValidateUserCredentials(model.UserName, model.Password);
                if (!user)
                {
                    return Unauthorized();
                }
                var token = _user.GenerateToken(model);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(UserCreateDTO model)
        {
            var result = await _user.CreateUser(model);
            return Ok(result);
        }

    }
}

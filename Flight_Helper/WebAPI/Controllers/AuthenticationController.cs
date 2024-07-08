using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _user;

        public AuthenticationController(IConfiguration configuration, IUserServices user )
        {
            _configuration = configuration;
            _user = user;
        }
        [HttpPost("authenticate")]
        public async Task< ActionResult<string>> Authenticate(AuthenticationModel authenticateRequestBody)
        {
            var user = await _user.ValidateUserCredentials(
            authenticateRequestBody.UserName,
            authenticateRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserName.ToString()));
            claimsForToken.Add(new Claim("given_name", user.PhoneNumber));
            claimsForToken.Add(new Claim("family_name", user.Email));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(AuthenticationModel model)
        {
           var result = await _user.CreateUser(model);
return Ok(result);
        }
        
    }
}

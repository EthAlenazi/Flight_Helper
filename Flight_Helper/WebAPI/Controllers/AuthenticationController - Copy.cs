using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [ApiVersion(2)] //This for versioning All API inside controller
    public class AuthenticationController_ : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _user;

        public AuthenticationController_(IConfiguration configuration, IUserServices user )
        {
            _configuration = configuration;
            _user = user;
        }
        [HttpPost("LogIn")]
        [ApiVersion(0.1, Deprecated = true)]//To inform user this version will expired
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
            claimsForToken.Add(new Claim("sub", user.UserName));
            claimsForToken.Add(new Claim("PhoneNumber", user.PhoneNumber));

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
        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(AuthenticationModel model)
        {
            var result = await _user.CreateUser(model);
            return Ok(result);
        }
        
    }
}

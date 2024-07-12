using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Data;
using WebAPI.DTO.Create;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUsersRepository _user;
        private readonly IConfiguration _configuration;
        public UserServices(IUsersRepository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        public async Task<bool> ValidateUserCredentials(string userName, string password)
        {
            var user = await _user.GetUserAsync(userName, password);
            if (user == null)
                return false;
            return true;

        }
        public async Task<IdentityUser> GetTokenuser(string userName, string password)
        {
            var user = await _user.GetUserAsync(userName, password);
            return user;
        }
        public async Task<bool> CreateUser(UserCreateDTO model)
        {
            User user = new User
            {
                PhoneNumber = model.PhoneNumber,
                PasswordHash=model.Password,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                Role=model.Role,
                NormalizedUserName=model.FullName
            };
            _user.AddUserAsync(user);
            return true;
        }

        public string GenerateToken(AuthenticationModel model)
        {
            try
            {
                var user = GetTokenuser(model.UserName, model.Password);
                var securityKey = new SymmetricSecurityKey(
                    Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));
                var signingCredentials = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Result.UserName));
                claimsForToken.Add(new Claim("PhoneNumber", user.Result.PhoneNumber));

                var jwtSecurityToken = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials);

                var tokenToReturn = new JwtSecurityTokenHandler()
                   .WriteToken(jwtSecurityToken);
                return tokenToReturn;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }



    }
}

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
        public async Task<string> ValidateUserCredentials(string userName, string password)
        {
            User user = await _user.GetUserAsync(userName, password);
            if (user == null)
                return "User Not Found!";
           var token=  GenerateToken(user);
            return token;

        }
        public async Task<IdentityUser> GetTokenuser(string userName, string password)
        {
            var user = await _user.GetUserAsync(userName, password);
            return user;
        }
        public async Task<bool> CreateUser(UserDTO model)
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
            bool result =await _user.AddUserAsync(user);
            if(result)
                return true;

            return false;
        }

        public string GenerateToken(User model)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(
                    Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));
                var signingCredentials = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", model.UserName));
                claimsForToken.Add(new Claim("PhoneNumber", model.PhoneNumber));

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

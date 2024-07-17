using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly JwtSettings _jwtSettings;
        private readonly StaticCredentials _staticCredentials;
        public UserServices(IUsersRepository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        public async Task<bool> IsValidDynamicUser(LoginModel model)
        {
            User user = await _user.GetUserAsync(model.Username, model.Password);
            if (user == null)
                return false;
            return true;

        }
        public async Task<bool> IsValidStaticUser(LoginModel login)
        {
            return false;// login.Username ==  _staticCredentials.Username && login.Password == _staticCredentials.Password;
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

        public string GenerateToken(string username)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }



    }
}

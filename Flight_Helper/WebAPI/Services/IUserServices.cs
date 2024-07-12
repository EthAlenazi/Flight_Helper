using Microsoft.AspNetCore.Identity;
using WebAPI.DTO.Create;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserServices
    {
       Task<string> ValidateUserCredentials(string userName, string password);
       //Task<bool>CreateUser(AuthenticationModel model);
       //string GenerateToken(AuthenticationModel model);
       Task<bool> CreateUser(UserCreateDTO model);
    }
}
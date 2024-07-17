using Microsoft.AspNetCore.Identity;
using WebAPI.DTO.Create;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserServices
    {
       Task<bool> IsValidDynamicUser(LoginModel model);
       Task<bool> IsValidStaticUser(LoginModel login);
       string GenerateToken(string username);
       Task<bool> CreateUser(UserDTO model);
    }
}
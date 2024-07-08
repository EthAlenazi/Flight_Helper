using Microsoft.AspNetCore.Identity;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserServices
    {
       Task<IdentityUser> ValidateUserCredentials(string userName, string password);
       Task<bool>CreateUser(AuthenticationModel model);
    }
}
using Microsoft.AspNetCore.Identity;
using WebAPI.Data;

namespace WebAPI.Entities
{
    public interface IUsersRepository
    {
        Task<IdentityUser> GetUserAsync(string userName, string Pass);
        Task<bool> AddUserAsync(User user);
    }
}
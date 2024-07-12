using Microsoft.AspNetCore.Identity;
using WebAPI.Data;

namespace WebAPI.Entities
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(string userName, string Pass);
        Task<bool> AddUserAsync(User user);
    }
}
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Entities
{
    public interface IUsersRepository
    {
        Task<IdentityUser> GetUserAsync(string userName, string Pass);
    }
}
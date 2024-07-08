using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Entities
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FlightHelperDBContext _dbContext;
        public UsersRepository(FlightHelperDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IdentityUser> GetUserAsync(string userName, string Pass)
        {
            return await _dbContext.customers.FirstOrDefaultAsync(u => (u.UserName == userName)&&(u.PasswordHash==Pass));
        }

    }
}

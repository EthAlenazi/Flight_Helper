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

        public async Task<User> GetUserAsync(string userName, string Pass)
        {
           var user = await _dbContext.Users.FirstOrDefaultAsync(u => (u.UserName == userName)&&(u.PasswordHash==Pass));
           return user; 
        }
        public async Task<bool> AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}

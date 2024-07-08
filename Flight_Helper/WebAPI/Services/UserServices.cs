using Microsoft.AspNetCore.Identity;
using WebAPI.Entities;
using WebAPI.Migrations;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUsersRepository _user;
        public UserServices(IUsersRepository user)
        {
            _user = user;
        }
        public async Task<IdentityUser> ValidateUserCredentials(string userName, string password)
        {
            var user = await _user.GetUserAsync(userName, password);
            if (user == null)
                return null;
            return user;

        }
        public async Task<bool> CreateUser(AuthenticationModel model)
        {

            return true;
        }



    }
}

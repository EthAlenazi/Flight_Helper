using System.ComponentModel.DataAnnotations;

namespace TripSite.Models
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public int Role { get; set; } 
        public bool Gender { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

}

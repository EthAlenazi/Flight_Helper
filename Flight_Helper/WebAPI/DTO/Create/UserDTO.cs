using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO.Create
{
    public class UserDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^\\+966\\d{9}$", ErrorMessage = "Enter a valid phone number as +966 followed by 9 digits.")]
        public string PhoneNumber { get; set; }
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[Required]
        //[AllowedValues(typeof(Role))]
        public Role Role { get; set; }
        [Required]
        //[AllowedValues(0, 1)]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int AccessFailedCount { get; set; } = 6;
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TripSite.ViewModel
{
    public class RegisterViewModel
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

        public int Role { get; set; } = 3; //customert
        [Required]
        public bool Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public enum Gender
    {
        Female = 0,
        Male = 1
    }
}

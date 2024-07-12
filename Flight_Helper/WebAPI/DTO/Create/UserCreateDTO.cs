using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO.Create
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^\\+\\d{1,3}\\d{9}$", ErrorMessage = " Enter valid phone as +966 500000000")]
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
        [StringLength(100, MinimumLength = 15)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int AccessFailedCount { get; set; } = 6;
    }
}

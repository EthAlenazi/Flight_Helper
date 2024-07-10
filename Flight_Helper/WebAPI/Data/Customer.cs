using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace WebAPI.Data
{

    /// <summary>
    /// Represents a customer in our site.
    /// This class is used to access and generate tokens.
    /// </summary>
    public class Customer : IdentityUser
    {
        
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^\\+\\d{1,3}\\d{9}$",ErrorMessage =" Enter valid phone as +966 500000000")]
        public override string PhoneNumber { get; set; }

        [Required]
        public Gender Gender { get; set; } 

        [ForeignKey("RoleId")]
        public string RoleId { get; set; }

        public Roles Role { get; set; } // Navigation property
    }

    public enum Gender
    {
        Male,
        Female
    }
}

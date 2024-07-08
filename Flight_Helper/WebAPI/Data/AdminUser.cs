using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents admin users for controlling 
    /// the dashboard application with specific roles.
    /// </summary>
    public class AdminUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [ForeignKey("RoleId")]
        public string RoleId { get; set; }

        public Roles Role { get; set; }
        [Required]
        [RegularExpression("^\\+\\d{1,3}\\d{9}$", ErrorMessage = " Enter valid phone as +966 500000000")]
        public string PhoneNumber { get; set; }


    }
}

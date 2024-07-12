using Microsoft.AspNetCore.Identity;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a user of the trip planning application.
    /// Inherits from IdentityUser to include authentication properties.
    /// </summary>
    /// <param name="Role">Role of the user, e.g., Admin or Client.</param>
    /// <param name="Gender">Gender of the user, either Male or Female.</param>
    public class User : IdentityUser
    {
        public Role Role { get; set; }
        public Gender Gender { get; set; }
      
        // Navigation properties
        public List<Trip>? Trip { get; set; }
    }
    public enum Gender
    {
        Female,
        Male
    }
    public enum Role
    {
        AdminFullAccess,
        AdminViewData,
        Client
    }
}

using Microsoft.AspNetCore.Identity;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents the different roles in our site.
    /// Admin roles: FullAccess, ReadOnly
    /// Customer roles: Guest, LoggedIn
    /// </summary>
    public class Roles : IdentityRole
    {
        public RoleType RoleType { get; set; }
        public AdminRoleType? AdminRole { get; set; }
        public CustomerRoleType? CustomerRole { get; set; }
    }

    public enum RoleType
    {
        Admin,
        Customer
    }

    public enum AdminRoleType
    {None,
        FullAccess,
        ReadOnly
    }

    public enum CustomerRoleType
    {
        Guest,
        LoggedIn
    }
}


using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class FlightHelperDBContext : DbContext
    {
        public FlightHelperDBContext(DbContextOptions<FlightHelperDBContext> options) : base(options)
        { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<AdminUser> adminUsers { get; set; }
        public DbSet<Roles> roles { get; set; }

    }
    
}

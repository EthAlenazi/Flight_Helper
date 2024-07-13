using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class FlightHelperDBContext : IdentityDbContext
    {
        public FlightHelperDBContext(DbContextOptions<FlightHelperDBContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationType> AccommodationType { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityTpye> ActivityType { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
    
}

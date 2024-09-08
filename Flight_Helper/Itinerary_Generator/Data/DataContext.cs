using Itinerary_Generator.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Itinerary_Generator.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        
        DbSet<User> Users { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Preference> preferences { get; set; }
        DbSet<Transport> Transports { get; set; }
        DbSet<Itinerary> Itineraries { get; set; }
        DbSet<Day> Days { get; set; }
        DbSet<DailyActivity> DailyActivities { get; set; }
        DbSet<DailyTransport> DailyTransports { get; set; }
        DbSet<LookupTransportType> lookupTransportTypes { get; set; }
        DbSet<LookupActivitityType> lookupActivitityTypes { get; set; }
        DbSet<LookupDestination> lookupDestinations { get; set; }
    }
}

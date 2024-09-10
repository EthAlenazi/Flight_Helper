using ItineraryGenerator.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItineraryGenerator.Data
{
    public class DataContext :DbContext
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
        DbSet<LookupTransportType> LookupTransportTypes { get; set; }
        DbSet<LookupActivitityType> LookupActivitityTypes { get; set; }
        DbSet<LookupDestination> LookupDestinations { get; set; }
    }
}

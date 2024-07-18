namespace TripSite.ViewModel
{
    public class CreateTrip
    {
            public int? UserID { get; set; }
            public string TripName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal Budget { get; set; }
            public string? Notes { get; set; }
            public int NumberOfPassengers { get; set; }
        }
    }


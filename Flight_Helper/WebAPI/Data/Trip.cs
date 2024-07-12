using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a trip planned by a user.
    /// Contains details like trip name, dates,
    /// budget, and the number of passengers.
    /// </summary>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="User_ID">Unique identifier for the user who created the trip.</param>
    /// <param name="TripName">Name of the trip.</param>
    /// <param name="StartDate">Start date of the trip.</param>
    /// <param name="EndDate">End date of the trip.</param>
    /// <param name="Budget">Budget allocated for the trip.</param>
    /// <param name="Notes">Additional notes about the trip.</param>
    /// <param name="NumberOfPassengers">Number of passengers for the trip.</param>
    /// <example>
    /// John creates a trip to Paris 
    /// from August 1st to August 10th 
    /// with a budget of $2000 and 2 passengers.
    /// </Example>
    public class Trip 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripID { get; set; }
        public int User_ID { get; set; }
        public string TripName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        /// <summary>
        /// additional notes for the trip.
        /// </summary>
        public string? Notes { get; set; }
        public int NumberOfPassengers { get; set; }

        // Navigation properties
        public User User { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Accommodation> Accommodations { get; set; }
        public List<Transport> Transports { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Companion> Companions { get; set; }

    }
}


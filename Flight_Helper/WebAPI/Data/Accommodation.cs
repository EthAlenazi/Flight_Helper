using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents an accommodation booked for a trip.
    /// Includes details such as name, address, 
    /// check-in/check-out dates, and cost.
    /// </summary>
    /// <param name="AccommodationID">Unique identifier for the accommodation.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Name">Name of the accommodation.</param>
    /// <param name="Address">Address of the accommodation.</param>
    /// <param name="CheckInDate">Check-in date and time.</param>
    /// <param name="CheckOutDate">Check-out date and time.</param>
    /// <param name="Cost">Total cost of the accommodation.</param>
    /// <example>
    /// Atheer books a hotel named "Paris Inn" 
    /// from August 1st to August 10th,
    /// costing $800.
    /// </example>

    public class Accommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccommodationID { get; set; }
        public int TripID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Cost { get; set; }

        // Navigation property
        public Trip Trip { get; set; }
    }
}

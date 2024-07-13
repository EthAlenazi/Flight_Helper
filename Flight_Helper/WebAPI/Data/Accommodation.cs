using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents an accommodation booked for a trip.
    /// Includes details such as check-in/check-out dates.
    /// </summary>
    /// <param name="AccommodationID">Unique identifier for the accommodation.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="AccommodationTypeID">Unique identifier for the accommodation type.</param>
    /// <param name="CheckInDate">Check-in date and time.</param>
    /// <param name="CheckOutDate">Check-out date and time.</param>
    /// <param name="Note">For add note.</param>
    /// <example>
    /// Atheer books a hotel named "Paris Inn" 
    /// from August 1st to August 10th.
    /// </example>
    public class Accommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccommodationID { get; set; }
        public int AccommodationTypeID { get; set; }
        public int TripID { get; set; }
        public string Note { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Navigation property
        public Trip Trip { get; set; }
        public AccommodationType AccommodationName { get; set; }
    }
  
}

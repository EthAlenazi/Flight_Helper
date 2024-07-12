using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a destination within a trip.
    /// Includes details such as name, country, city, 
    /// and arrival/departure dates.
    /// </summary>
    /// <param name="DestinationID">Unique identifier for the destination.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Name">Name of the destination.</param>
    /// <param name="Country">Country of the destination.</param>
    /// <param name="City">City of the destination.</param>
    /// <param name="ArrivalDate">Arrival date and time.</param>
    /// <param name="DepartureDate">Departure date and time.</param>
    /// <example>
    /// For his Paris trip,
    /// Atheer adds "Eiffel Tower" as a destination,
    /// with arrival on August 2nd and 
    /// departure on August 2nd.
    /// </example>
    public class Destination 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DestinationID { get; set; }
        public int TripID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        // Navigation property
        public Trip Trip { get; set; }
    }
}

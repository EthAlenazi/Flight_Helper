using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a mode of transport within a trip.
    /// Includes details such as type,
    /// departure/arrival locations and dates, and cost.
    /// </summary>
    /// <param name="TransportID">Unique identifier for the transport.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Type">Type of transport (e.g., Flight, Train, Car Rental).</param>
    /// <param name="DepartureLocation">Departure location of the transport.</param>
    /// <param name="ArrivalLocation">Arrival location of the transport.</param>
    /// <param name="DepartureDateTime">Departure date and time.</param>
    /// <param name="ArrivalDateTime">Arrival date and time.</param>
    /// <param name="Cost">Total cost of the transport.</param>
    /// <example>
    /// Atheer books a flight from New York to Paris, 
    /// departing on August 1st and arriving on August 1st,
    /// costing $500.
    /// </example>
    public class Transport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportID { get; set; }
        public int TripID { get; set; }
        public int TransportTypeID { get; set; } 
        public string Note { get; set; } 
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        // Navigation property
        public Trip Trip { get; set; }
        public TransportType TransportType { get; set; }
    }
}

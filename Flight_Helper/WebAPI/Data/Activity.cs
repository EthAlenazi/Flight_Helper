using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents an activity planned within a trip.
    /// Includes details such as name,
    /// description, date/time, and cost.
    /// </summary>
    /// <param name="ActivityID">Unique identifier for the activity.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Name">Name of the activity.</param>
    /// <param name="Description">Description of the activity.</param>
    /// <param name="DateTime">Date and time of the activity.</param>
    /// <param name="Cost">Total cost of the activity.</param>
    /// <example>
    /// Atheer plans a guided tour of 
    /// the Louvre Museum on August 3rd,
    /// costing $50.
    /// </example>
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityID { get; set; }
        public int ActivityTypeID { get; set; }
        public int TripID { get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }

        // Navigation property 
        public Trip Trip { get; set; }
        public ActivityTpye ActivityTpye { get; set; }  

    }
    
}
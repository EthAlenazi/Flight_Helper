using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a companion joining a trip.
    /// Includes details such as name, contact information,
    /// relationship to the client, and gender.
    /// </summary>
    /// <param name="CompanionID">Unique identifier for the companion.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Name">Name of the companion.</param>
    /// <param name="ContactInformation">Contact information for the companion.</param>
    /// <param name="RelationshipToClient">Relationship of the companion to the client.</param>
    /// <param name="Gender">Gender of the companion.</param>
    /// <example>
    /// Atheer adds his family member as
    /// a companion for the Paris trip.
    /// </example>
    public class Companion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanionID { get; set; }
        public int TripID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string RelationshipToClient { get; set; }
        public Gender Gender { get; set; }

        // Navigation property
        public Trip Trip { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents different types of activities that can be selected.
    /// </summary>
    /// <param name="TransportTypeID">Unique identifier for the transport type.</param>
    /// <param name="Name">Name of the transport type.</param>
    /// <param name="Description">Description of the transport type.</param>
    /// <param name="Cost">Cost associated with the transport type.</param>
    /// <example>
    /// Example of an transpoty type:
    ///     Name = "Cra Rental",
    ///     Cost: 50$ 
    /// </code>
    /// </example>
    public class TransportType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportTypeID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        // Navigation property fro Admin
        public List<Transport> Transport { get; set; }

    }
}

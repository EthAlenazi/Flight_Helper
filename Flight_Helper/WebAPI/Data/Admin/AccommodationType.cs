using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a type of accommodation that can be selected by the user.
    /// Includes details such as name, address, and cost.
    /// </summary>
    /// <param name="AccommodationTypeID">Unique identifier for the accommodation type.</param>
    /// <param name="Name">Name of the accommodation type.</param>
    /// <param name="Address">Address of the accommodation type.</param>
    /// <param name="Cost">Cost of the accommodation type.</param>
    /// <example>
    /// "Paris Inn" with address "123 Paris St, Paris, France" costing $800.
    /// </example>
    public class AccommodationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccommodationTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        // Navigation properties for Admin dashboard
        public List<Accommodation> Accommodations { get; set; }
    }
}


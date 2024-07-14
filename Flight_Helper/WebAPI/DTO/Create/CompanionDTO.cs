using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class CompanionDTO
    {
        [Required]
        public int TripID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ContactInformation { get; set; }

        [StringLength(50)]
        public string RelationshipToClient { get; set; }

        [Required]
        [AllowedValues(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}

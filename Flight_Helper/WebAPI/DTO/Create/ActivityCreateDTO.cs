using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class ActivityCreateDTO
    {
        [Required]
        public int TripID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO.Create.Admin
{
    public class ActivityTypeDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }
    }
}

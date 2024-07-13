using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO.Create.Admin
{
    public class TransportTypeCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }
        [Required]
        public string Description { get; set; }
    }


}

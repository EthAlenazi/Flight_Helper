using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class TransportCreateDTO
    {
        [Required]
        public int TripID { get; set; }

        [Required]
        [AllowedValues(typeof(TransportType))]
        public int Type { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartureLocation { get; set; }

        [Required]
        [StringLength(100)]
        public string ArrivalLocation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }
    }

   
}

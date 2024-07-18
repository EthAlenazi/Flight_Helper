using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class TransportViewModel
    {
        public int TripID { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartureLocation { get; set; }

        [Required]
        [StringLength(100)]
        public string ArrivalLocation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DepartureDateTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public List<SelectListItem> TransportTypes { get; set; }
    }

   
}

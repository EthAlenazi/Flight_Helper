using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class DestinationDTO
    {
        //[Required]
        public int TripID { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(100)]
        public string Country { get; set; }

        //[StringLength(100)]
        public string City { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}

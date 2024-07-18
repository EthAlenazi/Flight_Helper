using System.ComponentModel.DataAnnotations;
using WebAPI.Data;
using WebAPI.DTO.Create;

namespace WebAPI.DTO
{
    public class TripDTO
    {
        
        public int TripId { get; set; }
        public int? UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string TripName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfPassengers { get; set; }
    }
    public class TripCreateDTO
    {
        public int? UserID { get; set; }
        public string TripName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public string? Notes { get; set; }
        public int NumberOfPassengers { get; set; }
        public List<DestinationDTO> Destinations { get; set; }
        public List<AccommodationDTO> Accommodations { get; set; }
        public List<TransportDTO> Transports { get; set; }
        public List<ActivityDTO> Activities { get; set; }
        public List<ExpenseDTO> Expenses { get; set; }
        public List<CompanionDTO> Companions { get; set; }
    }

}

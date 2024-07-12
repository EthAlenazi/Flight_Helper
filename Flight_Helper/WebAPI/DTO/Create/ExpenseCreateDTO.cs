using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class ExpenseCreateDTO
    {
        [Required]
        public int TripID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

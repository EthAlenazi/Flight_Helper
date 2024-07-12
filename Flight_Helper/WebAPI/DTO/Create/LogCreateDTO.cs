using System.ComponentModel.DataAnnotations;
using WebAPI.Data;

namespace WebAPI.DTO
{
    public class LogCreateDTO
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(100)]
        public string Service { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string Method { get; set; }

        [Required]
        public int Status { get; set; }

        [StringLength(500)]
        public string StatusDescription { get; set; }

        [StringLength(1000)]
        public string Request { get; set; }

        [StringLength(1000)]
        public string Response { get; set; }
    }
}

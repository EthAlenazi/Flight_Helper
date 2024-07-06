using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
    }
}

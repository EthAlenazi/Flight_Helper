using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class CustomerOrders
    {
        [Key]
        public int Id { get; set; }
    }
}

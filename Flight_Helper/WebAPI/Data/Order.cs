using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
    }
}

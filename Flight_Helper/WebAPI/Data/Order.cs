using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public bool Paid { get; set; }

    }
}

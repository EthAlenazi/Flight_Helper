using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{

    /// <summary>
    /// 
    /// </summary>
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }//Guid will effect to the performance,
    }
}

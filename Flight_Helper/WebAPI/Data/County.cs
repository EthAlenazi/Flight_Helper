using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class County//and city when we add value as parent Id
    {
        [Key]
        public int Id { get; set; }
    }
}

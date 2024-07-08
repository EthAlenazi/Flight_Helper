using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public int CountryName { get; set; }
        public bool IsActive { get; set; }
        public List<City> Cities { get; set; } // represented as one country have multiple of cities
    }

}

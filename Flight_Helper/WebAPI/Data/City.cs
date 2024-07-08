using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country Country { get; set; } //represented as one City has one country
    }
}

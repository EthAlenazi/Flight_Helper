using System.ComponentModel.DataAnnotations;

namespace ItineraryGenerator.Data.Model
{
    public class DailyActivity
    {
        [Key]
        public int ID { get; set; }
        public int ActivityID { get; set; }
        public int DayID { get; set; }

    }
}

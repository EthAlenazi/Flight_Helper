using System.ComponentModel.DataAnnotations;

namespace ItineraryGenerator.Data.Model
{
    public class DailyTransport
    {
        [Key]
        public int ID { get; set; }
        public int TransportID { get; set; }
        public int DayID { get; set; }

    }
}

namespace Itinerary_Generator.Data.Model
{
    public class DailyTransport
    {
        public int DailyTransportID { get; set; }
        public int TransportID { get; set; }
        public int DayID { get; set; }
        public Transport Transport { get; set; }
        public Day Day { get; set; }

    }
}

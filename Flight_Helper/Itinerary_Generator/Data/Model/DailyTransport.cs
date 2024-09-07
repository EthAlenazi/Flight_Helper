namespace Itinerary_Generator.Data.Model
{
    public class DailyTransport
    {
        public DailyTransport(Transport transport,Day day)
        {
            this.transport = transport;
            this.day = day;
            
        }
        public int DailyTransportID { get; set; }
        public int TransportID { get; set; }
        public int DayID { get; set; }
        public Transport transport { get; set; }
        public Day day { get; set; }

    }
}

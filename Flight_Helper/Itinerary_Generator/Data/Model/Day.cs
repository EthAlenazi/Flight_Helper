namespace Itinerary_Generator.Data.Model
{
    public class Day
    {
        public Day(Transport transport,Itinerary itinerary)
        {
            this.transport = transport;
            this.itinerary = itinerary;
            
        }
        public int DayID { get; set; }
        public int ItineraryID { get; set; }
        public int TransportID { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public Itinerary itinerary { get; set; }
        public Transport transport { get; set; }

    }
}

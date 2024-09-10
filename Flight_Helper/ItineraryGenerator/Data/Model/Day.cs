namespace ItineraryGenerator.Data.Model
{
    public class Day
    {
        public int ID { get; set; }
        public int ItineraryID { get; set; }
        public int TransportID { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public Itinerary Itinerary { get; set; }
        public Transport Transport { get; set; }

    }
}

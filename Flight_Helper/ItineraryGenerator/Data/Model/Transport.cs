namespace ItineraryGenerator.Data.Model
{
    public class Transport
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public decimal Cost { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public LookupTransportType LookupTransportType { get; set; }
    }
}

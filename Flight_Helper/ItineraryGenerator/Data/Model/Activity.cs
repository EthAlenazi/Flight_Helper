namespace ItineraryGenerator.Data.Model
{
    public class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public LookupTransportType LookupTransportTypes { get; set; }

    }
}

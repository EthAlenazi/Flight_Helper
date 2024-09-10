namespace ItineraryGenerator.Data.Model
{
    public class Preference
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ActivityType { get; set; }
        public LookupTransportType  LookupTransportType { get; set; }
    }
}

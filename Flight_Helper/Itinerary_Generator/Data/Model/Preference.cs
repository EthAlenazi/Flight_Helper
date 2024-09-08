namespace Itinerary_Generator.Data.Model
{
    public class Preference
    {
        public int PreferenceID { get; set; }
        public int UserID { get; set; }
        public string ActivityType { get; set; }
        public LookupTypes LookupTypes { get; set; }
    }
}

namespace ItineraryGenerator.Data.Model
{
    public class Itinerary
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TotalCost { get; set; }
        public bool PDFGenerated { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public User user { get; set; }

    }
}

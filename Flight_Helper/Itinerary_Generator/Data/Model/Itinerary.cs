namespace Itinerary_Generator.Data.Model
{
    public class Itinerary
    {
        public Itinerary(User user)
        {
            this.user = user;
        }
        public int ItineraryID { get; set; }
        public int UserID { get; set; }
        public int TotalCost { get; set; }
        public bool PDFGenerated { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public User user { get; set; }

    }
}

namespace Itinerary_Generator.Data.Model
{
    public class DailyActivity
    {

        public int DailyActivityID { get; set; }
        public int ActivityID { get; set; }
        public int DayID { get; set; }
        public Activity Activity { get; set; }
        public Day Day { get; set; }
    }
}

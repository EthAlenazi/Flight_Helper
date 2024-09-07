namespace Itinerary_Generator.Data.Model
{
    public class DailyActivity
    {
        public DailyActivity(Activity activity,Day day)
        {
            this.activity = activity;
            this.day = day;            
        }
        public int DailyActivityID { get; set; }
        public int ActivityID { get; set; }
        public int DayID { get; set; }
        public Activity activity { get; set; }
        public Day day { get; set; }
    }
}

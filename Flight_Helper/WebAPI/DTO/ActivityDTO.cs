namespace WebAPI.DTO
{
    public class ActivityDTO
    {
        public int ActivityID { get; set; }
        public int ActivityTypeID { get; set; }
        public int TripID { get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }
    }
}

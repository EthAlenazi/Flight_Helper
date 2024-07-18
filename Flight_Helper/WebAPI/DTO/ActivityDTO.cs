using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAPI.DTO
{
    public class ActivityDTO
    {
        public int ActivityID { get; set; }
        public int TripID { get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }
        public List<SelectListItem> ActivityTypes { get; set; }
    }
}

﻿namespace Itinerary_Generator.Data.Model
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public LookupTypes LookupTypes { get; set; }

    }
}

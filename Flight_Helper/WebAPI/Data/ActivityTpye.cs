using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents different types of activities that can be selected.
    /// </summary>
    /// <param name="ActivityTypeID">Unique identifier for the activity type.</param>
    /// <param name="Name">Name of the activity type.</param>
    /// <param name="Description">Description of the activity type.</param>
    /// <param name="Cost">Cost associated with the activity type.</param>
    /// <example>
    /// Example of an activity type:
    /// <code>
    /// var activityType = new ActivityType
    /// {
    ///     Name = "Guided Tour",
    ///     Description = "A guided tour of historical landmarks.",
    ///     Cost: 50$
    /// };
    /// </code>
    /// </example>
    public class ActivityTpye
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        // Navigation properties for Admin dashboard
        public List<Activity> Activity { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents a log of actions performed within a system. 
    /// Includes details such as action type, description, and date.
    /// </summary>
    /// <param name="LogID">Unique identifier for the log entry.</param>
    /// <param name="Time">Time when the action was performed.</param>
    /// <param name="Service">Service where the action was performed.</param>
    /// <param name="Action">Type of action performed.</param>
    /// <param name="Method">Method used in the action.</param>
    /// <param name="Status">Status code of the action.</param>
    /// <param name="StatusDescription">Description of the status.</param>
    /// <param name="Request">Request details.</param>
    /// <param name="Response">Response details.</param>
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        public DateTime Time { get; set; }
        public string Service { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public int Status { get; set; }
        public int StatusDescription { get; set; }
        public string? Request { get; set; }
        public string? Response { get; set; }
    }
}

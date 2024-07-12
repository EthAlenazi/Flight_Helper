using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data
{
    /// <summary>
    /// Represents an expense incurred during a trip.
    /// Includes details such as description,
    /// amount, and date.
    /// </summary>
    /// <param name="ExpenseID">Unique identifier for the expense.</param>
    /// <param name="TripID">Unique identifier for the trip.</param>
    /// <param name="Description">Description of the expense.</param>
    /// <param name="Date">Date and time of the expense.</param>
    /// <param name="Amount">Amount of the expense.</param>
    /// <example>
    /// Atheer records an expense for
    /// dining at a restaurant on August 2nd,
    /// costing $100.
    /// </example>
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpenseID { get; set; }
        public int TripID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Navigation property
        public Trip Trip { get; set; }

    }
}

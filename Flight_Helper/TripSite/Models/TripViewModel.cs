﻿using System.ComponentModel.DataAnnotations;

namespace TripSite.Models
{
    public class TripViewModel
    {
        public int TripId { get; set; }
        public int? UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string TripName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfPassengers { get; set; }
    }

    public class DestinationViewModel
    {
        //[Required]
        public int TripID { get; set; } = 2;

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(100)]
        public string Country { get; set; }

        //[StringLength(100)]
        public string City { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}

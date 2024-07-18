using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;
using TripSite.Models;
using TripSite.ViewModel;

namespace TripSite.Controllers
{
    public class UserTripController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var model = new TripViewModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                //for test perpos
                TripId= 3
            }; // Initialize with default values if needed
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TripViewModel model)
        {
            model.TripId = 3;
            if (ModelState.IsValid)
            {
                // Handle form submission, e.g., save to database

                //ater valid save i want send data responce to the next viwe AddDestination with trip id 
                return RedirectToAction("AddDestination", new { trip = model });
            }

            // If validation fails, redisplay the form
            return View(model);
           
        }

        [HttpGet]
        public IActionResult AddDestination(TripViewModel trip)
        {
            var model = new DestinationViewModel
            {
                TripID = trip.TripId,
                ArrivalDate= DateTime.Now,
                DepartureDate= DateTime.Now.AddDays(6),
            }; // Initialize with default values if needed
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDestination(DestinationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle form submission, e.g., save to database
                RedirectToAction();
            }

            // If validation fails, redisplay the form
            return View(model);
        }
    }
}

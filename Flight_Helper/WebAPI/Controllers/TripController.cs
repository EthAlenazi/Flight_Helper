using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/Trip")]
    public class TripController : Controller
    {
        [HttpPost]
        [Route("CreateTripPlan")]
        public IActionResult CreateTripPlan(TripDTO model)
        {
            return View();
        }
        [HttpPost]
        [Route("CancelTripPlan")]

        public IActionResult CancelTripPlan(TripDTO model)
        {
            return View();
        }
        [HttpPost]
        [Route("Re-generateAPlanTrip")]
        public IActionResult RegenerateAPlanTrip(TripDTO model)
        {
            return View();
        }

    }
}

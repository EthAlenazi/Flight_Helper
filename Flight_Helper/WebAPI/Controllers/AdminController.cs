using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Controllers
{
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        [HttpPost]
        [Route("GetUsersDetails")]
        public IActionResult GetUsersDetails()
        {
            return View();
        }
        [HttpPost]
        [Route("UpdateUserDetails")]
        public IActionResult UpdateUserDetails(UserCreateDTO userCreate)
        {
            return View();
        }
        [HttpPost]
        [Route("GetTripsDetails")]
        public IActionResult GetTripsDetails()
        {
            return View();
        }
        [HttpPost]
        [Route("AddTransportType")]
        public IActionResult AddTransportType(ActivityTypeCreateDTO activityType)
        {
            return View();
        }
        [HttpPost]
        [Route("AddAccommodationType")]
        public IActionResult AddAccommodationType(AccommodationCreateDTO accommodationType)
        {
            return View();
        }
        [HttpPost]
        [Route("AddAccommodationType")]
        public IActionResult AddActivityType(ActivityTypeCreateDTO activityType)
        {
            return View();
        }
    }
}

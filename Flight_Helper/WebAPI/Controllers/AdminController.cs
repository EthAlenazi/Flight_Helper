using Microsoft.AspNetCore.Mvc;

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
        [Route("GetUsersDetails")]
        public IActionResult GetTripsDetails()
        {
            return View();
        }
        [HttpPost]
        [Route("GetUsersDetails")]
        public IActionResult AddToService()
        {
            return View();
        }
        [HttpPost]
        [Route("GetUsersDetails")]
        public IActionResult UpdateService()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/Trip")]
    public class TripController : Controller
    {
        [HttpPost]
        public IActionResult CreateTripPlan(TripCreateDTO model)
        {
            return View();
        }
    }
}

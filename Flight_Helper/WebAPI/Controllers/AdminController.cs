using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create;
using WebAPI.DTO.Create.Admin;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/Admin")]
    public class AdminController : Controller
    {private readonly IActivityTypeService _activityTypeService;
        public AdminController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
            
        }
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
        public IActionResult AddTransportType(ActivityTypeDTO activityType)
        {
            return View();
        }
        [HttpPost]
        [Route("AddAccommodationType")]
        public IActionResult AddAccommodationType(AccommodationCreateDTO accommodationType)
        {
            return View();
        }

        #region Activity
        [HttpPost]
        [Route("AddActivityType")]
        public IActionResult AddActivityType(ActivityTypeDTO activityType)
        {
          var Data=  _activityTypeService.AddActivityTypeAsync(activityType);
            return Ok("Activity type added");
        }
        [HttpPost]
        [Route("UpdateActivityType")]
        public IActionResult UpdateActivityType(ActivityTypeDTO activityType)
        {
            _activityTypeService.UpdateActivityTypeAsync(activityType);
            return View();
        }
        [HttpPost]
        [Route("RemoveActivityType")]
        public IActionResult RemoveActivityType(ActivityTypeDTO activityType)
        {
            _activityTypeService.DeleteActivityTypeAsync(activityType.Id);
            return View();
        }
        [HttpPost]
        [Route("GetAllActivityType")]
        public IActionResult GetAllActivityType()
        {
            _activityTypeService.GetAllActivityTypesAsync();
            return View();
        }
        #endregion
    }
}

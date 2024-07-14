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
    {
    private readonly IActivityTypeService _activityTypeService;
    private readonly ITransportTypeService _transportTypeService;
        public AdminController(IActivityTypeService activityTypeService, ITransportTypeService transportTypeService)
        {
            _activityTypeService = activityTypeService;
            _transportTypeService = transportTypeService;
            
        }
        [HttpPost]
        [Route("GetUsersDetails")]
        public IActionResult GetUsersDetails()
        {
            return View();
        }
        [HttpPost]
        [Route("UpdateUserDetails")]
        public IActionResult UpdateUserDetails(UserDTO userCreate)
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
        [Route("AddAccommodationType")]
        public IActionResult AddAccommodationType(AccommodationDTO accommodationType)
        {
            return View();
        }

        #region Transport
        [HttpPost]
        [Route("AddTransportType")]
        public IActionResult AddTransportType(TransportTypeDTO activityType)
        {
            var Data = _transportTypeService.AddTransportTypeAsync(activityType);
            return Ok("Transport type added");
        }
        [HttpPost]
        [Route("UpdateTransportType")]
        public IActionResult UpdateTransportType(TransportTypeDTO activityType)
        {
            var result = _transportTypeService.UpdateTransportTypeAsync(activityType);
            return Ok(result);
        }
        [HttpPost]
        [Route("RemoveTransportType")]
        public IActionResult RemoveTransportType(TransportTypeDTO activityType)
        {
            var result = _activityTypeService.DeleteActivityTypeAsync(activityType.Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAllTransportTypes")]
        public IActionResult GetAllTransportTypes()
        {
            var result = _transportTypeService.GetAllTransportTypesAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("GetTransportTypesById")]
        public IActionResult GetTransportTypesById(int Id)
        {
            var result = _transportTypeService.GetTransportTypeByIdAsync(Id);
            return Ok(result);
        }
        #endregion

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
            var result=_activityTypeService.UpdateActivityTypeAsync(activityType);
            return Ok(result);
        }
        [HttpPost]
        [Route("RemoveActivityType")]
        public IActionResult RemoveActivityType(ActivityTypeDTO activityType)
        {
            var result= _activityTypeService.DeleteActivityTypeAsync(activityType.Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAllActivityType")]
        public IActionResult GetAllActivityType()
        {
           var result= _activityTypeService.GetAllActivityTypesAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("GetActivityTypeById")]
        public IActionResult GetActivityTypeById(int Id)
        {
            var result = _activityTypeService.GetActivityTypeByIdAsync(Id);
            return Ok(result);
        }
        #endregion
    }
}

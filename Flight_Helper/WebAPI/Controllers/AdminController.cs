using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create;
using WebAPI.DTO.Create.Admin;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
    private readonly IActivityTypeService _activityTypeService;
    private readonly ITransportTypeService _transportTypeService;
        private readonly IAccommodationTypeService _accommodationTypeService;
        public AdminController(IActivityTypeService activityTypeService, ITransportTypeService transportTypeService
            , IAccommodationTypeService accommodationTypeService)
        {
            _activityTypeService = activityTypeService;
            _transportTypeService = transportTypeService;
            _accommodationTypeService = accommodationTypeService;
        }
        #region User
        [HttpPost]
        [Route("GetAllUsers")]
        public IActionResult GetaAllUsers()
        {
            return View();
        }
        [HttpPost]
        [Route("ControlUserAccess")]
        public IActionResult ControlUserAccess(Guid userId)
        {
            return View();
        }
        #endregion
        #region Trip
        [HttpPost]
        [Route("GetTripsDetails")]
        public IActionResult GetTripsDetails(int id)
        {
            return View();
        }
        [HttpPost]
        [Route("UpdateTripsDetails")]
        public IActionResult UpdateTripsDetails(int id)
        {
            return View();
        }
        [HttpPost]
        [Route("GetAllTrips")]
        public IActionResult GetAllTrips()
        {
            return View();
        }
        #endregion
        #region Accommodation
        [HttpPost]
        [Route("AddAccommodationType")]
        public IActionResult AddAccommodationType(AccommodationTypeDTO activityType)
        {
            var Data = _accommodationTypeService.AddAccommodationTypeAsync(activityType);
            return Ok("Accommodation type added");
        }
        [HttpPost]
        [Route("UpdateAccommodationType")]
        public IActionResult UpdateAccommodationType(AccommodationTypeDTO activityType)
        {
            var result = _accommodationTypeService.UpdateAccommodationTypeAsync(activityType);
            return Ok(result);
        }
        [HttpPost]
        [Route("RemoveAccommodationType")]
        public IActionResult RemoveAccommodationType(AccommodationTypeDTO activityType)
        {
            var result = _accommodationTypeService.DeleteAccommodationTypeAsync(activityType.Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAllAccommodationTypes")]
        public IActionResult GetAllAccommodationTypes()
        {
            var result = _accommodationTypeService.GetAllAccommodationTypesAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAccommodationTypesById")]
        public IActionResult GetAccommodationTypesById(int Id)
        {
            var result = _accommodationTypeService.GetAccommodationTypeByIdAsync(Id);
            return Ok(result);
        }
        #endregion
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

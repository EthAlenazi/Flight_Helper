using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create;
using WebAPI.DTO.Create.Admin;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private readonly IActivityTypeService _activityTypeService;
        private readonly ITransportTypeService _transportTypeService;
        private readonly IAccommodationTypeService _accommodationTypeService;
        private readonly ITripServices _tripsService;

        public AdminController(IActivityTypeService activityTypeService, ITransportTypeService transportTypeService
            , IAccommodationTypeService accommodationTypeService, ITripServices tripsService)
        {
            _activityTypeService = activityTypeService;
            _transportTypeService = transportTypeService;
            _accommodationTypeService = accommodationTypeService;
            _tripsService = tripsService;
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
        [HttpPost("GetTripsDetails")]
        public async Task<IActionResult> GetTripDetails(int Id)
        {
            var result = await _tripsService.GetTripWithDetailsAsync(Id);

            if (result.Error != Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.Result);
        }
        [HttpPost]
        [Route("UpdateTripsDetails")]
        public IActionResult UpdateTripsDetails(int id)
        {
            return View();
        }
        [HttpPost]
        [Route("GetAllTrips")]
        public async  Task<IActionResult> GetAllTrips()
        {
            var result = await _tripsService.GetAllTrip();
            if (result.Error != Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.Results);
        }
        #endregion
        #region Accommodation
        [HttpPost("AddAccommodationType")]
        public async Task<IActionResult> AddAccommodationType(AccommodationTypeDTO activityType)
        {
            var result =await  _accommodationTypeService.AddAccommodationTypeAsync(activityType);
            if (result.Error!=Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.ErrorMessage);
        }
        [HttpPost("UpdateAccommodationType")]
        public async Task<IActionResult> UpdateAccommodationType(AccommodationTypeDTO activityType)
        {
            var result =await _accommodationTypeService.UpdateAccommodationTypeAsync(activityType);
            if (result.Error != Errors.Success)
                return Ok(result.Result);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("RemoveAccommodationType")] 
        public async Task<IActionResult> RemoveAccommodationType(int Id)
        {
            var result = await _accommodationTypeService.DeleteAccommodationTypeAsync(Id);
            if (result.Error != Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.ErrorMessage);
        }
        [HttpPost("GetAllAccommodationTypes")] 
        public async Task<IActionResult> GetAllAccommodationTypes()
        {
            var result =await _accommodationTypeService.GetAllAccommodationTypesAsync();
            if (result.Error != Errors.Success)
                return BadRequest(result.Results);
            return Ok(result.Results);
        }
        [HttpPost("GetAccommodationTypesById")]
        public async Task<IActionResult> GetAccommodationTypesById(int Id)
        {
            var result = await _accommodationTypeService.GetAccommodationTypeByIdAsync(Id);
            if (result.Error != Errors.Success)
                return Ok(result.ErrorMessage);
            return Ok(result.Result);
        }
        #endregion
        #region Transport
        [HttpPost("AddTransportType")]
        public async Task<IActionResult> AddTransportType(TransportTypeDTO activityType)
        {
            var result = await _transportTypeService.AddTransportTypeAsync(activityType);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ErrorMessage);
        }
        [HttpPost("UpdateTransportType")]
        public async Task<IActionResult> UpdateTransportType(TransportTypeDTO activityType)
        {
            var result = await _transportTypeService.UpdateTransportTypeAsync(activityType);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ErrorMessage);
        }
        [HttpPost("RemoveTransportType")]
        public async Task<IActionResult> RemoveTransportType(int Id)
        {
            var result = await _transportTypeService.DeleteTransportTypeAsync(Id);
            if (result.Error == Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        [HttpPost("GetAllTransportTypes")] 
        public async Task<IActionResult> GetAllTransportTypes()
        {
            var result = await _transportTypeService.GetAllTransportTypesAsync();
            if (result.Error !=Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Results);
        }
        [HttpPost("GetTransportTypesById")]
        public async Task<IActionResult> GetTransportTypesById(int Id)
        {
            var result = await _transportTypeService.GetTransportTypeByIdAsync(Id);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        #endregion
        #region Activity
        [HttpPost("AddActivityType")]
        public async Task<IActionResult> AddActivityType(ActivityTypeDTO activityType)
        {
          var result = await  _activityTypeService.AddActivityTypeAsync(activityType);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ErrorMessage);
        }
        [HttpPost("UpdateActivityType")]
        public async Task<IActionResult> UpdateActivityType(ActivityTypeDTO activityType)
        {
            var result=await _activityTypeService.UpdateActivityTypeAsync(activityType);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ErrorMessage);
        }
        [HttpPost("RemoveActivityType")]
        public async Task<IActionResult> RemoveActivityType(int Id)
        {
            var result=await _activityTypeService.DeleteActivityTypeAsync(Id);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ErrorMessage);
        }
        [HttpPost("GetAllActivityType")]
        public async Task<IActionResult> GetAllActivityType()
        {
            var result = await _activityTypeService.GetAllActivityTypesAsync();
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Results);
        }
        [HttpPost("GetActivityTypeById")]
        public async Task<IActionResult> GetActivityTypeById(int Id)
        {
            var result =await _activityTypeService.GetActivityTypeByIdAsync(Id);
            if (result.Error != Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        #endregion
    }
}

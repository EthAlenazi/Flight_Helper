using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ResponseCache(CacheProfileName = "40SecondsCacheProfile")]
    public class TripChoicesController : Controller
    {
        private readonly IActivityTypeService _activityTypeService;
        private readonly ITransportTypeService _transportTypeService;
        private readonly IAccommodationTypeService _accommodationTypeService;
        public TripChoicesController(IActivityTypeService activityTypeService, ITransportTypeService transportTypeService
            , IAccommodationTypeService accommodationTypeService)
        {
            _activityTypeService = activityTypeService;
            _transportTypeService = transportTypeService;
            _accommodationTypeService = accommodationTypeService;
        }
        [HttpGet]
        [Route("GetAllActivityType")]
        //[ResponseCache(Duration = 120)]
        public async Task<IActionResult> GetAllActivityType()
        {
            var result = await _activityTypeService.GetAllActivityTypesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTransportTypes")]
        public async Task<IActionResult> GetAllTransportTypes()
        {
            var result =await  _transportTypeService.GetAllTransportTypesAsync();
            if (result.Error==DTO.Errors.Success)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllAccommodationTypes")]
        public async Task<IActionResult> GetAllAccommodationTypes()
        {
            var result =await _accommodationTypeService.GetAllAccommodationTypesAsync();
            if (result.Error == DTO.Errors.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
    }
}

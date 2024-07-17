using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/Trip")]
    public class TripController : Controller
    {
        private readonly ITripServices _tripsService;
        private readonly IPdfService _pdfService;
        public TripController(ITripServices tripServices, IPdfService pdfService)
        {
            _tripsService = tripServices;
            IPdfService _pdfService;
        }
        [HttpPost("CreateTripPlan")]
        public async Task<IActionResult> CreateTrip(TripCreateDTO tripCreateDTO)
        {
            var result = await _tripsService.CreateTripAsync(tripCreateDTO);

            if (result.Error != Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.ErrorMessage);
        }
        [HttpPost("GetTripDetails")]
        public async Task<IActionResult> GetTripDetails(int Id)
        {
            var result = await _tripsService.GetTripWithDetailsAsync(Id);

            if (result.Error != Errors.Success)
                return BadRequest(result.ErrorMessage);
            return Ok(result.Result);
        }
        [HttpPost("Re-generateAPlanTrip")]
        public async Task<IActionResult> GenerateTripPdf(int id)
        {
            var response = await _tripsService.GetTripWithDetailsAsync(id);

            if (response.Error == Errors.NotFound)
            {
                return NotFound(response);
            }

            if (response.Error == Errors.ServerError)
            {
                return StatusCode(500, response);
            }

            var tripDto = response.Result;
            // Generate PDF
            var pdfBytes = _pdfService.GenerateTripPdf(tripDto);

            // Return PDF as file
            return File(pdfBytes, "application/pdf", "trip_details.pdf");
        }
    }



}


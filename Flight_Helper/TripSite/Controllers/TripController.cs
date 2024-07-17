using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ApiService _tripsService;

    public TripsController(ApiService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<TripDTO>>> GetTripWithDetails(int id)
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

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<TripDTO>>> CreateTrip(TripCreateDTO tripCreateDTO)
    {
        var response = await _tripsService.CreateTripAsync(tripCreateDTO);

        if (response.Error == Errors.ServerError)
        {
            return StatusCode(500, response);
        }

        return CreatedAtAction(nameof(GetTripWithDetails), new { id = response.Result.TripID }, response);
    }
}

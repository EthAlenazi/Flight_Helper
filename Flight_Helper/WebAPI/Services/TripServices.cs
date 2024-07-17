using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Services;

public class TripsService:ITripServices
{
    private readonly FlightHelperDBContext _context;
    private readonly IMapper _mapper;

    public TripsService(FlightHelperDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<TripDTO>> GetTripWithDetailsAsync(int Id)
    {
        var response = new Response<TripDTO>();
        try
        {
            var trip = await _context.Trips
                .Include(t => t.User)
                .Include(t => t.Destinations)
                .Include(t => t.Accommodations)
                .Include(t => t.Transports)
                .Include(t => t.Activities)
                .Include(t => t.Expenses)
                .Include(t => t.Companions)
                .FirstOrDefaultAsync(t => t.TripID == Id);

            if (trip == null)
            {
                response.Error = Errors.NotFound;
                response.ErrorMessage = "No Data Found!";
                return response;
            }

            var tripDTO = _mapper.Map<TripDTO>(trip);

            response.Error = Errors.Success;
            response.ErrorMessage = "Success";
            response.Result = tripDTO;
            return response;
        }
        catch (Exception ex)
        {
            response.Error = Errors.ServerError;
            response.ErrorMessage = ex.Message;
            return response;
        }
    }

    public async Task<Response<TripDTO>> CreateTripAsync(TripCreateDTO tripCreateDTO)
    {
        var response = new Response<TripDTO>();
        try
        {
            var trip = _mapper.Map<Trip>(tripCreateDTO);

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            var tripDTO = _mapper.Map<TripDTO>(trip);

            response.Error = Errors.Success;
            response.ErrorMessage = "Trip created successfully";
            response.Result = tripDTO;
            return response;
        }
        catch (Exception ex)
        {
            // Handle exception (log it, etc.)
            response.Error = Errors.ServerError;
            response.ErrorMessage = ex.Message;
            response.Result = null;
            return response;
        }
    }

    public async Task<Response<TripDTO>> GetAllTrip()
    {
        var response = new Response<TripDTO>();
        try
        {
            var trips = await _context.Trips
                .Include(t => t.User)
                .Include(t => t.Destinations)
                .Include(t => t.Accommodations)
                .Include(t => t.Transports)
                .Include(t => t.Activities)
                .Include(t => t.Expenses)
                .Include(t => t.Companions)
                .ToListAsync();

            if (trips == null || trips.Count == 0)
            {
                response.Error = Errors.NotFound;
                response.ErrorMessage = "No Data Found!";
                return response;
            }

            var tripDTOs = _mapper.Map<List<TripDTO>>(trips);

            response.Error = Errors.Success;
            response.ErrorMessage = "Success";
            response.Results = tripDTOs;
            return response;
        }
        catch (Exception ex)
        {
            // Handle exception (log it, etc.)
            response.Error = Errors.ServerError;
            response.ErrorMessage = ex.Message;
            return response;
        }
    }


    public async Task<Response<TripDTO>> UpdateTripAsync(TripDTO trip)
    {
        var response = new Response<TripDTO>();
        try
        {
            var entity = await _context.Trips
                .Include(t => t.User)
                .Include(t => t.Destinations)
                .Include(t => t.Accommodations)
                .Include(t => t.Transports)
                .Include(t => t.Activities)
                .Include(t => t.Expenses)
                .Include(t => t.Companions)
                .FirstOrDefaultAsync(t => t.TripID == trip.TripId);

            if (trip == null)
            {
                response.Error = Errors.NotFound;
                response.ErrorMessage = "No Data Found!";
                return response;
            }

            var Data = _mapper.Map<Trip>(trip);

            _context.Update(Data);
            await _context.SaveChangesAsync();
            response.Error = Errors.Success; // No error
            response.ErrorMessage = "Trip updated successfully.";

            return response;
        }
        catch (Exception ex)
        {
            // Handle exception
            response.Error = Errors.ServerError; // Indicate an exception occurred
            response.Result = null;
            response.ErrorMessage = $"An error occurred while updating Trip: {ex.Message}";
            return response;
        }
    }
}

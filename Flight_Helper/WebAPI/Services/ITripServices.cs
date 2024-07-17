using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface ITripServices
    {
        Task<Response<TripDTO>> CreateTripAsync(TripCreateDTO tripCreateDTO);
        Task<Response<TripDTO>> GetTripWithDetailsAsync(int Id);
        Task<Response<TripDTO>> GetAllTrip();
    }
}

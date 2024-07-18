using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface IAddServices
    {
        Task<Response<TransportViewModel>> AddTransportAsync(TransportViewModel transport);
        Task<Response<ActivityDTO>> AddActivityAsync(ActivityDTO activity);
        Task<Response<AccommodationViweModel>> AddAccommodationAsync(AccommodationViweModel accommodation);

    }
}

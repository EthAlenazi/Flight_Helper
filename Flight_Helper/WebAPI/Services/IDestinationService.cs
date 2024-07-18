using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IDestinationService
    {
        Task<Response<DestinationDTO>> AddDestinationAsync(DestinationDTO destination);
    }
}

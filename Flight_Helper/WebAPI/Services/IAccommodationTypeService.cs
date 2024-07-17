using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface IAccommodationTypeService
    {
        Task<Response<AccommodationTypeDTO>> GetAllAccommodationTypesAsync();
        Task<Response<AccommodationTypeDTO>> GetAccommodationTypeByIdAsync(int id);
        Task<Response<AccommodationTypeDTO>> AddAccommodationTypeAsync(AccommodationTypeDTO accommodationType);
        Task<Response<AccommodationTypeDTO>> UpdateAccommodationTypeAsync(AccommodationTypeDTO accommodationType);
        Task<Response<AccommodationTypeDTO>> DeleteAccommodationTypeAsync(int id);
    }
}

using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface IAccommodationTypeService
    {
        Task<List<AccommodationTypeDTO>> GetAllAccommodationTypesAsync();
        Task<AccommodationTypeDTO> GetAccommodationTypeByIdAsync(int id);
        Task AddAccommodationTypeAsync(AccommodationTypeDTO activityTypeDTO);
        Task<bool> UpdateAccommodationTypeAsync(AccommodationTypeDTO activityTypeDTO);
        Task<bool> DeleteAccommodationTypeAsync(int id);
    }
}

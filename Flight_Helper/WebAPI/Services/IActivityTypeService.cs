using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface IActivityTypeService
    {
        Task<List<ActivityTypeDTO>> GetAllActivityTypesAsync();
        Task<ActivityTypeDTO> GetActivityTypeByIdAsync(int id);
        Task AddActivityTypeAsync(ActivityTypeDTO activityTypeDTO);
        Task<bool> UpdateActivityTypeAsync(ActivityTypeDTO activityTypeDTO);
        Task<bool> DeleteActivityTypeAsync(int id);
    }
}

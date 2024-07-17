using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface IActivityTypeService
    {
        Task<Response<ActivityTypeDTO>> GetAllActivityTypesAsync();
        Task<Response<ActivityTypeDTO>> GetActivityTypeByIdAsync(int id);
        Task<Response<ActivityTypeDTO>> AddActivityTypeAsync(ActivityTypeDTO activityTypeDTO);
        Task<Response<ActivityTypeDTO>> UpdateActivityTypeAsync(ActivityTypeDTO activityTypeDTO);
        Task<Response<ActivityTypeDTO>> DeleteActivityTypeAsync(int id);
    }
}

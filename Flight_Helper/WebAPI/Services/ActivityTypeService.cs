using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;
using WebAPI.Repository.Interface;

namespace WebAPI.Services
{
    public class ActivityTypeService:IActivityTypeService
    {
        private readonly IRepository<ActivityType> _activityTypeRepository;

        public ActivityTypeService(IRepository<ActivityType> activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        public async Task<Response<ActivityTypeDTO>> GetAllActivityTypesAsync()
        {
            var response = new Response<ActivityTypeDTO>();
            try
            {
                var entities = await _activityTypeRepository.GetAllAsync();
                if (entities == null || !entities.Any())
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "No Data Found!";
                    response.Result = null;
                    response.Results = new List<ActivityTypeDTO>();
                    return response;
                }
                response.Error = Errors.Success;
                response.ErrorMessage = "success";
                response.Results = entities.Select(a => new ActivityTypeDTO
                {
                    Id = a.ActivityTypeID,
                    Name = a.Name,
                    Cost = a.Cost,
                    Description = a.Description
                }).ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; 
                response.ErrorMessage = ex.ToString();
                response.Request = $"{nameof(GetAllActivityTypesAsync)}";
                return response;
            }
        }

        public async Task<Response<ActivityTypeDTO>> GetActivityTypeByIdAsync(int id)
        {
            var response = new Response<ActivityTypeDTO>();
            try
            {
                var entity = await _activityTypeRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound; // Set an error code indicating the entity was not found
                    response.ErrorMessage = "No Data Found!";
                    return response;
                }
                response.Error = Errors.Success; // No error
                response.ErrorMessage = "success";
                response.Result = new ActivityTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description
                };
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = ex.ToString();
                response.Request = $"{nameof(GetActivityTypeByIdAsync)} for id({id})"; // Success message
                return response;
            }
        }

        public async Task<Response<ActivityTypeDTO>> AddActivityTypeAsync(ActivityTypeDTO activityType)
        {
            var response = new Response<ActivityTypeDTO>();
            try
            {
                var entity = new ActivityType
                {
                    Name = activityType.Name,
                    Cost = activityType.Cost,
                    Description = activityType.Description,
                };
                await _activityTypeRepository.AddAsync(entity);
                await _activityTypeRepository.SaveChangesAsync();
                var savedDTO = new ActivityTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description,
                };
                response.Error = Errors.Success;
                response.Result = savedDTO;
                response.ErrorMessage = "Activity type added successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Activity type: {ex.ToString()}";
                return response;
            }
        }

        public async Task<Response<ActivityTypeDTO>> UpdateActivityTypeAsync( ActivityTypeDTO activityType)
        {
            var response = new Response<ActivityTypeDTO>();
            try
            {
                var entity = await _activityTypeRepository.GetByIdAsync(activityType.Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Activity type not found.";
                    return response;
                }
                entity.Name = activityType.Name;
                entity.Cost = activityType.Cost;
                entity.Description = activityType.Description;
                _activityTypeRepository.Update(entity);
                await _activityTypeRepository.SaveChangesAsync();
                var updatedDTO = new ActivityTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description,
                };
                response.Error = Errors.Success;
                response.Result = updatedDTO;
                response.ErrorMessage = "Activity type updated successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = $"An error occurred while updating Activity type: {ex.ToString()}";
                return response;
            }
        }

        public async Task<Response<ActivityTypeDTO>> DeleteActivityTypeAsync(int Id)
        {
            var response = new Response<ActivityTypeDTO>();
            try
            {
                var entity = await _activityTypeRepository.GetByIdAsync(Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Activity type not found.";
                    return response;
                }
                _activityTypeRepository.Delete(entity);
                await _activityTypeRepository.SaveChangesAsync();
                response.Error = Errors.Success;
                response.ErrorMessage = "Activity type deleted successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = $"An error occurred while deleting Activity type: {ex.ToString()}";
                return response;
            }
        }
    }

}

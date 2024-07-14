using WebAPI.Data;
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

        public async Task<List<ActivityTypeDTO>> GetAllActivityTypesAsync()
        {
            var entities = await _activityTypeRepository.GetAllAsync();
            return entities.Select(a => new ActivityTypeDTO
            {
                Id = a.ActivityTypeID,
                Name = a.Name,
                Cost = a.Cost,
                Description = a.Description
            }).ToList();
        }

        public async Task<ActivityTypeDTO> GetActivityTypeByIdAsync(int id)
        {
            var entity = await _activityTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new ActivityTypeDTO
            {
                Id = entity.ActivityTypeID,
                Name = entity.Name,
                Cost = entity.Cost,
                Description = entity.Description
            };
        }

        public async Task AddActivityTypeAsync(ActivityTypeDTO activityTypeDTO)
        {
            var entity = new ActivityType
            { 
                Name = activityTypeDTO.Name,
                Cost = activityTypeDTO.Cost,
                Description = activityTypeDTO.Description,
            };

            await _activityTypeRepository.AddAsync(entity);
            await _activityTypeRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateActivityTypeAsync( ActivityTypeDTO activityTypeDTO)
        {
            var entity = await _activityTypeRepository.GetByIdAsync(activityTypeDTO.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Name = activityTypeDTO.Name;
            entity.Cost = activityTypeDTO.Cost;
            entity.Description = activityTypeDTO.Description;

            _activityTypeRepository.Update(entity);
            await _activityTypeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActivityTypeAsync(int id)
        {
            var entity = await _activityTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _activityTypeRepository.Delete(entity);
            await _activityTypeRepository.SaveChangesAsync();
            return true;
        }
    }

}

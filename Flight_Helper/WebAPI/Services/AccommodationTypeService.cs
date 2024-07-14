using WebAPI.Data;
using WebAPI.DTO.Create.Admin;
using WebAPI.Repository.Interface;

namespace WebAPI.Services
{
    public class AccommodationTypeService : IAccommodationTypeService
    {
        private readonly IRepository<AccommodationType> _accommodationTypeRepository;

        public AccommodationTypeService(IRepository<AccommodationType> accommodationTypeRepository)
        {
            _accommodationTypeRepository = accommodationTypeRepository;
        }

        public async Task<List<AccommodationTypeDTO>> GetAllAccommodationTypesAsync()
        {
            var entities = await _accommodationTypeRepository.GetAllAsync();
            return entities.Select(a => new AccommodationTypeDTO
            {
                Id = a.AccommodationTypeID,
                Name = a.Name,
                Cost = a.Cost,
                Address = a.Address
            }).ToList();
        }

        public async Task<AccommodationTypeDTO> GetAccommodationTypeByIdAsync(int id)
        {
            var entity = await _accommodationTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new AccommodationTypeDTO
            {
                Id = entity.AccommodationTypeID,
                Name = entity.Name,
                Cost = entity.Cost,
                Address = entity.Address
            };
        }

        public async Task AddAccommodationTypeAsync(AccommodationTypeDTO activityTypeDTO)
        {
            var entity = new AccommodationType
            { 
                Name = activityTypeDTO.Name,
                Cost = activityTypeDTO.Cost,
                Address = activityTypeDTO.Address,
            };

            await _accommodationTypeRepository.AddAsync(entity);
            await _accommodationTypeRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAccommodationTypeAsync( AccommodationTypeDTO activityTypeDTO)
        {
            var entity = await _accommodationTypeRepository.GetByIdAsync(activityTypeDTO.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Name = activityTypeDTO.Name;
            entity.Cost = activityTypeDTO.Cost;
            entity.Address = activityTypeDTO.Address;

            _accommodationTypeRepository.Update(entity);
            await _accommodationTypeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAccommodationTypeAsync(int id)
        {
            var entity = await _accommodationTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _accommodationTypeRepository.Delete(entity);
            await _accommodationTypeRepository.SaveChangesAsync();
            return true;
        }
    }

}

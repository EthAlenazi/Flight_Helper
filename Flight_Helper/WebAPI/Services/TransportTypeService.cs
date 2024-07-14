using WebAPI.Data;
using WebAPI.DTO.Create.Admin;
using WebAPI.Repository.Interface;

namespace WebAPI.Services
{
    public class TransportTypeService : ITransportTypeService
    {
        private readonly IRepository<TransportType> _transportTypeRepository;

        public TransportTypeService(IRepository<TransportType> activityTypeRepository)
        {
            _transportTypeRepository = activityTypeRepository;
        }

        public async Task<List<TransportTypeDTO>> GetAllTransportTypesAsync()
        {
            var entities = await _transportTypeRepository.GetAllAsync();
            return entities.Select(a => new TransportTypeDTO
            {
                Id = a.TransportTypeID,
                Name = a.Name,
                Cost = a.Cost,
                Description = a.Description
            }).ToList();
        }

        public async Task<TransportTypeDTO> GetTransportTypeByIdAsync(int id)
        {
            var entity = await _transportTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new TransportTypeDTO
            {
                Id = entity.TransportTypeID,
                Name = entity.Name,
                Cost = entity.Cost,
                Description = entity.Description
            };
        }

        public async Task AddTransportTypeAsync(TransportTypeDTO activityTypeDTO)
        {
            var entity = new TransportType
            { 
                Name = activityTypeDTO.Name,
                Cost = activityTypeDTO.Cost,
                Description = activityTypeDTO.Description,
            };

            await _transportTypeRepository.AddAsync(entity);
            await _transportTypeRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateTransportTypeAsync( TransportTypeDTO activityTypeDTO)
        {
            var entity = await _transportTypeRepository.GetByIdAsync(activityTypeDTO.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Name = activityTypeDTO.Name;
            entity.Cost = activityTypeDTO.Cost;
            entity.Description = activityTypeDTO.Description;

            _transportTypeRepository.Update(entity);
            await _transportTypeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransportTypeAsync(int id)
        {
            var entity = await _transportTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _transportTypeRepository.Delete(entity);
            await _transportTypeRepository.SaveChangesAsync();
            return true;
        }
    }

}

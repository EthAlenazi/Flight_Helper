using WebAPI.Data;
using WebAPI.DTO;
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

        public async Task<Response<AccommodationTypeDTO>> GetAllAccommodationTypesAsync()
        {
            var response = new Response<AccommodationTypeDTO>();
            try
            {
                var entities = await _accommodationTypeRepository.GetAllAsync();
                if (entities == null || !entities.Any())
                {
                    response.Error = Errors.NotFound; // Set an error code or use appropriate error handling
                    response.ErrorMessage = "No Data Found!";
                    response.Result = null;
                    response.Results = new List<AccommodationTypeDTO>(); // Or null, based on your preference
                    return response;
                }

                response.Error = Errors.Success; // No error
                response.Result = null; // Single result is not applicable here
                response.ErrorMessage = "success";
                response.Results = entities.Select(a => new AccommodationTypeDTO
                {
                    Id = a.AccommodationTypeID,
                    Name = a.Name,
                    Cost = a.Cost,
                    Address = a.Address
                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = ex.Message;
                response.Request = $"{nameof(GetAllAccommodationTypesAsync)}"; // Success message
                response.Results = null;
                return response;
            }
        }

        public async Task<Response<AccommodationTypeDTO>> GetAccommodationTypeByIdAsync(int id)
        {
            var response = new Response<AccommodationTypeDTO>();
            try
            {
                var entity = await _accommodationTypeRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound; 
                    response.ErrorMessage = "No Data Found!";
                    return response;
                }
                response.Error = Errors.Success;
                response.ErrorMessage = "success";
                response.Result = new AccommodationTypeDTO
                {
                    Id = entity.AccommodationTypeID,
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Address = entity.Address
                };
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = ex.Message;
                response.Request = $"{nameof(GetAccommodationTypeByIdAsync)} for id({id})"; // Success message
                return response;
            }
        }

        public async Task<Response<AccommodationTypeDTO>> AddAccommodationTypeAsync(AccommodationTypeDTO accommodationType)
        {
            var response = new Response<AccommodationTypeDTO>();
            try
            {
                var entity = new AccommodationType
                {
                    Name = accommodationType.Name,
                    Cost = accommodationType.Cost,
                    Address = accommodationType.Address,
                };

                await _accommodationTypeRepository.AddAsync(entity);
                await _accommodationTypeRepository.SaveChangesAsync();

                var savedDTO = new AccommodationTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Address = entity.Address,
                };

                response.Error = Errors.Success; // No error
                response.Result = savedDTO;
                response.ErrorMessage = "Accommodation type added successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding accommodation type: {ex.Message}";

                return response;
            }
        }

        public async Task<Response<AccommodationTypeDTO>> UpdateAccommodationTypeAsync( AccommodationTypeDTO accommodationType)
        {
            var response = new Response<AccommodationTypeDTO>();

            try
            {
                var entity = await _accommodationTypeRepository.GetByIdAsync(accommodationType.Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Accommodation type not found.";
                    return response;
                }

                entity.Name = accommodationType.Name;
                entity.Cost = accommodationType.Cost;
                entity.Address = accommodationType.Address;

                _accommodationTypeRepository.Update(entity);
                await _accommodationTypeRepository.SaveChangesAsync();

                var updatedDTO = new AccommodationTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Address = entity.Address,
                };

                response.Error = Errors.Success; // No error
                response.Result = updatedDTO;
                response.ErrorMessage = "Accommodation type updated successfully.";

                return response;
            }
            catch (Exception ex)
            {
                // Handle exception
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.Result = null;
                response.ErrorMessage = $"An error occurred while updating accommodation type: {ex.Message}";
                return response;
            }
        }

        public async Task<Response<AccommodationTypeDTO>> DeleteAccommodationTypeAsync(int Id)
        {
            var response = new Response<AccommodationTypeDTO>();
            try
            {
                var entity = await _accommodationTypeRepository.GetByIdAsync(Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Accommodation type not found.";
                    return response;
                }

                _accommodationTypeRepository.Delete(entity);
                await _accommodationTypeRepository.SaveChangesAsync();

                response.Error = Errors.Success; 
                response.ErrorMessage = "Accommodation type deleted successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; 
                response.Result = null;
                response.ErrorMessage = $"An error occurred while deleting accommodation type: {ex.Message}";
                return response;
            }
        }
    }

}

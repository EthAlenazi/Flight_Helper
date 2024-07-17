using WebAPI.Data;
using WebAPI.DTO;
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
        public async Task<Response<TransportTypeDTO>> GetAllTransportTypesAsync()
        {
            var response = new Response<TransportTypeDTO>();
            try
            {
                var entities = await _transportTypeRepository.GetAllAsync();

                if (entities == null || !entities.Any())
                {
                    response.Error = Errors.NotFound; // Set an error code or use appropriate error handling
                    response.ErrorMessage = "No Data Found!";
                    response.Result = null;
                    response.Results = new List<TransportTypeDTO>(); // Or null, based on your preference
                    return response;
                }

                response.Error = Errors.Success; // No error
                response.Result = null; // Single result is not applicable here
                response.ErrorMessage = "success";
                response.Results = entities.Select(a => new TransportTypeDTO
                {
                    Id = a.TransportTypeID,
                    Name = a.Name,
                    Cost = a.Cost,
                    Description = a.Description
                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.Result = null;
                response.Results = null;
                // Optionally, add more error information (e.g., exception message)
                return response;
            }
        }

        public async Task<Response<TransportTypeDTO>> GetTransportTypeByIdAsync(int id)
        {
            var response = new Response<TransportTypeDTO>();
            try
            {
                var entity = await _transportTypeRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound; // Set an error code indicating the entity was not found
                    response.ErrorMessage = "No Data Found!";
                    return response;
                }
                response.Error = Errors.Success; // No error
                response.ErrorMessage = "success";
                response.Result = new TransportTypeDTO
                {
                    Id = entity.TransportTypeID,
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description
                };
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = ex.Message;
                response.Request = $"{nameof(GetTransportTypeByIdAsync)} for id({id})"; // Success message
                response.Results = null;
                return response;
            }
        }

        public async Task<Response<TransportTypeDTO>> AddTransportTypeAsync(TransportTypeDTO transportType)
        {
            var response = new Response<TransportTypeDTO>();
            try
            {
                var entity = new TransportType
                {
                    Name = transportType.Name,
                    Cost = transportType.Cost,
                    Description = transportType.Description,
                };

                await _transportTypeRepository.AddAsync(entity);
                await _transportTypeRepository.SaveChangesAsync();

                var savedDTO = new TransportTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description,
                };

                response.Error = Errors.Success; // No error
                response.Result = savedDTO;
                response.ErrorMessage = "Transport type added successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Transport type: {ex.Message}";

                return response;
            }
        }

        public async Task<Response<TransportTypeDTO>> UpdateTransportTypeAsync(TransportTypeDTO transportType)
        {
            var response = new Response<TransportTypeDTO>();
            try
            {
                var entity = await _transportTypeRepository.GetByIdAsync(transportType.Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Transport type not found.";
                    return response;
                }

                entity.Name = transportType.Name;
                entity.Cost = transportType.Cost;
                entity.Description = transportType.Description;

                _transportTypeRepository.Update(entity);
                await _transportTypeRepository.SaveChangesAsync();

                var updatedDTO = new TransportTypeDTO
                {
                    Name = entity.Name,
                    Cost = entity.Cost,
                    Description = entity.Description,
                };

                response.Error = Errors.Success; // No error
                response.Result = updatedDTO;
                response.ErrorMessage = "Transport type updated successfully.";

                return response;
            }
            catch (Exception ex)
            {
                // Handle exception
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.Result = null;
                response.ErrorMessage = $"An error occurred while updating Transport type: {ex.Message}";
                return response;
            }
        }
        public async Task<Response<TransportTypeDTO>> DeleteTransportTypeAsync(int Id)
        {
            var response = new Response<TransportTypeDTO>();
            try
            {
                var entity = await _transportTypeRepository.GetByIdAsync(Id);
                if (entity == null)
                {
                    response.Error = Errors.NotFound;
                    response.ErrorMessage = "Transport type not found.";
                    return response;
                }

                _transportTypeRepository.Delete(entity);
                await _transportTypeRepository.SaveChangesAsync();

                response.Error = Errors.Success;
                response.ErrorMessage = "Transport type deleted successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError;
                response.ErrorMessage = $"An error occurred while deleting Transport type: {ex.Message}";
                return response;
            }
        }
    }


}

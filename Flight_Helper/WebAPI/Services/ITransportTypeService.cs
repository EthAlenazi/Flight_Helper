using WebAPI.Data;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface ITransportTypeService
    {
        Task<List<TransportTypeDTO>> GetAllTransportTypesAsync();
        Task<TransportTypeDTO> GetTransportTypeByIdAsync(int id);
        Task AddTransportTypeAsync(TransportTypeDTO activityTypeDTO);
        Task<bool> UpdateTransportTypeAsync(TransportTypeDTO activityTypeDTO);
        Task<bool> DeleteTransportTypeAsync(int id);
    }
}

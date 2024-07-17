using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;

namespace WebAPI.Services
{
    public interface ITransportTypeService
    {
        Task<Response<TransportTypeDTO>> GetAllTransportTypesAsync();
        Task<Response<TransportTypeDTO>> GetTransportTypeByIdAsync(int id);
        Task<Response<TransportTypeDTO>> AddTransportTypeAsync(TransportTypeDTO activityTypeDTO);
        Task<Response<TransportTypeDTO>> UpdateTransportTypeAsync(TransportTypeDTO activityTypeDTO);
        Task<Response<TransportTypeDTO>> DeleteTransportTypeAsync(int id);
    }
}

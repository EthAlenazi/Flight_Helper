using AutoMapper;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;
using WebAPI.Repository.Interface;

namespace WebAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository<Destination> _destination;
        private readonly IMapper _mapper;

        public DestinationService(IRepository<Destination> destination, IMapper mapper)
        {
            _destination = destination;
            _mapper = mapper;
        }
        public async Task<Response<DestinationDTO>> AddDestinationAsync(DestinationDTO destination)
        {
            var response = new Response<DestinationDTO>();
            try
            {
                var entity =_mapper.Map<Destination>(destination);
               
                await _destination.AddAsync(entity);
                await _destination.SaveChangesAsync();
              
                response.Error = Errors.Success;
                response.Result = destination;
                response.ErrorMessage = "Destination added successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Destination : {ex.ToString()}";
                return response;
            }
        }

    }

}

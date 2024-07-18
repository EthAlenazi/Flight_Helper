using AutoMapper;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create.Admin;
using WebAPI.Repository.Interface;

namespace WebAPI.Services
{
    public class AddServices : IAddServices
    { 
        private readonly IMapper _mapper;
        private readonly IRepository<Transport> _transportRepository;
        private readonly IRepository<Accommodation> _accommodationRepository;
        private readonly IRepository<Activity> _activityRepository;
        public AddServices(IMapper mapper, IRepository<Activity> activity,
         IRepository<Transport> transport, IRepository<Accommodation> accommodation)
        {
            _mapper= mapper;
            _transportRepository= transport;
            _activityRepository= activity;
            _accommodationRepository= accommodation;
        }
       
        public async Task<Response<TransportViewModel>> AddTransportAsync(TransportViewModel transport)
        {
            var response = new Response<TransportViewModel>();
            try
            {
                var entity= _mapper.Map<Transport>(transport );

                await _transportRepository.AddAsync(entity);
                await _transportRepository.SaveChangesAsync();
                response.Error = Errors.Success; // No error
                response.Result = transport;
                response.ErrorMessage = "Transport added successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Transport: {ex.Message}";
                return response;
            }
        }

        public async Task<Response<ActivityDTO>> AddActivityAsync(ActivityDTO activity)
        {
            var response = new Response<ActivityDTO>();
            try
            {
                var entity = _mapper.Map<Activity>(activity);

                await _activityRepository.AddAsync(entity);
                await _activityRepository.SaveChangesAsync();
                response.Error = Errors.Success; // No error
                response.Result = activity;
                response.ErrorMessage = "Activity added successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Activity: {ex.Message}";
                return response;
            }
        }

        public async Task<Response<AccommodationViweModel>> AddAccommodationAsync(AccommodationViweModel accommodation)
        {
            var response = new Response<AccommodationViweModel>();
            try
            {
                var entity = _mapper.Map<Accommodation>(accommodation);

                await _accommodationRepository.AddAsync(entity);
                await _accommodationRepository.SaveChangesAsync();
                response.Error = Errors.Success; // No error
                response.Result = accommodation;
                response.ErrorMessage = "Accommodation added successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Error = Errors.ServerError; // Indicate an exception occurred
                response.ErrorMessage = $"An error occurred while adding Accommodation: {ex.Message}";
                return response;
            }
        }
    }


}

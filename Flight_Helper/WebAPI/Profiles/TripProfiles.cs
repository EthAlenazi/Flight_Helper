using AutoMapper;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.DTO.Create;

namespace WebAPI.Profiles
{
    public class TripProfiles:Profile
    {
        public TripProfiles()
        {
             //CreateMap<Trip,TripDTO>();
             CreateMap<TripDTO,Trip>();
             //CreateMap<TripCreateDTO, Trip>();
             CreateMap<Trip, TripCreateDTO>();
            CreateMap<Trip, TripDTO>()
    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.User_ID))
    .ReverseMap();
            CreateMap<TripCreateDTO, Trip>()
                .ForMember(dest => dest.User_ID, opt => opt.MapFrom(src => src.UserID));

            CreateMap<User,UserDTO>();
            CreateMap<UserDTO,User>();
            
            CreateMap<Transport,TransportViewModel>();
            CreateMap<Transport, TransportViewModel>();

            CreateMap<TransportViewModel, Transport>();

            CreateMap<Expense, ExpenseDTO>();
            CreateMap<ExpenseDTO, Expense>();

            CreateMap<Destination, DestinationDTO>();
            CreateMap<DestinationDTO, Destination>();

            CreateMap<Companion, CompanionDTO>();
            CreateMap<CompanionDTO, Companion>(); 

            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>(); 

            CreateMap<Accommodation, AccommodationViweModel>();
            CreateMap<AccommodationViweModel, Accommodation>();


        }
       
            //CreateMap<Trip, CityWithoutPointOfInterestDTO>();
            //CreateMap<City, CityDTO>();
            //CreateMap<PointOfInterest, PointOfInterestDTO>();
            //CreateMap<PointOfInterestForCreationDTO, PointOfInterest>();

            //CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();

            //CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
    }
}

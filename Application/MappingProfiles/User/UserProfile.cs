using AutoMapper;

namespace Application.MappingProfiles.User
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<Domain.Entities.User, DTOs.User.UserDto>();
            CreateMap<DTOs.User.UserDto, Domain.Entities.User>();
        }
    }
}

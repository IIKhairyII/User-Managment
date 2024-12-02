using AutoMapper;

namespace Application.MappingProfiles.User
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<Domain.Entities.User, Responses.User.UserDto>();
            CreateMap<Responses.User.UserDto, Domain.Entities.User>();
        }
    }
}

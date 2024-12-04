using Application.DTOs.User;
using MediatR;

namespace Application.Requests.User.Commands
{
    public class EditProfileCommandDto : IRequest<UserDto>
    {
        public UserDto userDto { get; set; }
    }
}

using Application.Responses.User;
using MediatR;

namespace Application.Requests.User.Commands
{
    public class EditProfileCommandDto : IRequest<UserDto>
    {
        public UserDto userDto { get; set; }
    }
}

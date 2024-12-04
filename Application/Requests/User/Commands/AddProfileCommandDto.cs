using Application.DTOs.User;
using MediatR;

namespace Application.Requests.User.Commands
{
    public class AddProfileCommandDto : IRequest<int>
    {
        public UserDto userDto { get; set; }
    }
}

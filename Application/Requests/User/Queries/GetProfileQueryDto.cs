using Application.DTOs.User;
using MediatR;

namespace Application.Requests.User.Queries
{
    public class GetProfileQueryDto : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

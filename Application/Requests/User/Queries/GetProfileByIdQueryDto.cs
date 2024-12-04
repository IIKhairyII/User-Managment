using Application.DTOs.User;
using MediatR;

namespace Application.Requests.User.Queries
{
    public class GetProfileByIdQueryDto : IRequest<UserDto>
    {
        public long Id { get; set; }
    }
}

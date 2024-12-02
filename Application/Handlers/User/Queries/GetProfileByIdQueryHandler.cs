using Application.Repositories;
using Application.Requests.User.Queries;
using Application.Responses.User;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.User.Queries
{
    public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQueryDto, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        public GetProfileByIdQueryHandler(IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<Domain.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }


        public async Task<UserDto> Handle(GetProfileByIdQueryDto request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByConditionAsync(u => u.Id == request.Id);

                if (user is null)
                    return null;
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

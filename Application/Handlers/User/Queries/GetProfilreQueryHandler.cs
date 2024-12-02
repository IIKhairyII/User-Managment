using Application.Repositories;
using Application.Requests.User.Queries;
using Application.Responses.User;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.User.Queries
{
    public class GetProfilreQueryHandler : IRequestHandler<GetProfileQueryDto, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        public GetProfilreQueryHandler(IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<Domain.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDto> Handle(GetProfileQueryDto request, CancellationToken cancellationToken)
        {
            try
            {
                var hashedPassword = _passwordHasher.HashPassword(null, request.Password);
                var user = await _userRepository.GetByConditionAsync(u => u.Email == request.Email);

                if (user is null)
                    return null;
                bool isValidPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Success;
                if (!isValidPassword)
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

using Application.Repositories;
using Application.Requests.User.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.User.Commands
{
    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommandDto, int>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        public AddProfileCommandHandler(IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<Domain.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<int> Handle(AddProfileCommandDto request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.userDto is null)
                    return -1;
                var user = _mapper.Map<Domain.Entities.User>(request.userDto);
                user.Password = _passwordHasher.HashPassword(null, user.Password);
                int result = await _userRepository.AddAsync(user);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
